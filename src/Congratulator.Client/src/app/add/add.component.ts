import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BirthdayDate } from '../core/birthday-date.interface';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  id: number | undefined;
  birthdayDate: BirthdayDate = {
    id: 0,
    firstName: '',
    lastName: '',
    birthDate: new Date()
  }
  constructor(private _http: HttpClient, private _route: ActivatedRoute, private _router: Router) { }

  ngOnInit(): void {
    this.getId();
  }

  getId(): void {
    this.id = Number(this._route.snapshot.paramMap.get('id'));
    this.birthdayDate.id = this.id;
  }

  onSubmit() {
    let birthdayDateString = {
      ...this.birthdayDate,
      birthDate: this.birthdayDate.birthDate.toLocaleDateString("en-CA")
    };

    this._http.post<void>('Congratulator/api/birthdaydate', birthdayDateString).subscribe(() => {
      this._router.navigate(["/main"]);
    },
      error => {
        console.error(error);
      });
  }
}
