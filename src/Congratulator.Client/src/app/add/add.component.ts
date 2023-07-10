import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BirthdayDate } from '../core/birthday-date.interface';
import { Image } from '../core/image.interface';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})

export class AddComponent {
  birthdayDate: BirthdayDate = {
    id: 0,
    firstName: '',
    lastName: '',
    birthDate: new Date()
  }
  image: Image = {
    id: 0,
    birthdayId: 0,
    img: ''
  }
  isFileSelected = false;

  constructor(protected _http: HttpClient, protected _router: Router) { }

  onSubmit() {
    let birthdayDateString = {
      ...this.birthdayDate,
      birthDate: this.birthdayDate.birthDate.toLocaleDateString("en-CA")
    };

    this._http.post<{ id: number }>('Congratulator/api/birthdaydate', birthdayDateString).subscribe(result =>
    {
      this.image.birthdayId = result.id;
      this._http.post<void>('Congratulator/api/image', this.image).subscribe(() => {
        this._router.navigate(["/main"]);
      }, error => {
        console.error(error);
      })
    },
      error => {
        console.error(error);
      });
  }

  onFileChange(event: Event) {
    let input = event.target as HTMLInputElement;
    this.isFileSelected = !!(input.files && input.files.length > 0);
    if (input.files && input.files[0]) {
      let file = input.files[0];
      let reader = new FileReader();
      reader.onload = () => {
        //no support for pngs
        let result = reader.result as ArrayBuffer;
        let uint8array = new Uint8Array(result);
        let charArray = Array.from(uint8array, x => String.fromCharCode(x));
        let base64String = btoa(charArray.join(''));
        this.image.img = base64String;
      };
      reader.readAsArrayBuffer(file);
    }
  }
}
