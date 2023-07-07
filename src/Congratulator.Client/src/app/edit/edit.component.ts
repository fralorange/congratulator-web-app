import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BirthdayDate } from '../core/birthday-date.interface';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
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
    console.log('x');
    this._http.put<void>(`Congratulator/api/birthdaydate/${this.id}`, this.birthdayDate).subscribe(() =>
    {
      this._router.navigate(["/main"]);
    },
      error => {
        console.error(error);
      });
  }
}
