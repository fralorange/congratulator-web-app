import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BirthdayDate } from '../core/birthday-date.interface';
import { Image } from '../core/image.interface';
import { AddComponent } from '../add/add.component';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent extends AddComponent implements OnInit {
  id: number | undefined;

  constructor(_http: HttpClient, _router: Router, private _route: ActivatedRoute) {
    super(_http, _router);
  }

  ngOnInit(): void {
    this.getId();
  }

  getId(): void {
    this.id = Number(this._route.snapshot.paramMap.get('id'));
    this.birthdayDate.id = this.id;
    this.image.birthdayId = this.id;
  }

  override onSubmit() {
    let birthdayDateString = {
      ...this.birthdayDate,
      birthDate: this.birthdayDate.birthDate.toLocaleDateString("en-CA")
    };

    this._http.put<void>(`Congratulator/api/birthdaydate/${this.id}`, birthdayDateString).subscribe(() => {
      this._http.put<void>(`Congratulator/api/image/${this.id}`, this.image).subscribe(() => {
        this._router.navigate(["/main"]);
      }, error => {
        console.error(error);
      })
    },
      error => {
        console.error(error);
      });
  }
}
