import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public birthdayDates?: BirthdayDate[];

  constructor(http: HttpClient) {
    http.get<BirthdayDateCollection>('Congratulator/api/birthdaydate').subscribe(result => {
      this.birthdayDates = result.birthdays;
    }, error => console.error(error));
  }

  title = 'Congratulator.Client';
}

interface BirthdayDate {
  id: number;
  firstName: string;
  lastName: string;
  birthDate: Date;
}

interface BirthdayDateCollection {
  birthdays: BirthdayDate[];
}
