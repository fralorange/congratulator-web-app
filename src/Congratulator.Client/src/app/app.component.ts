import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public birthdayDates?: BirthdayDate[];

  constructor(private http: HttpClient) {
    this.loadData("Congratulator/api/birthdaydate");
  }

  title = 'Congratulator.Client';

  onCheckboxChange(event: Event) {
    const checked = (event.target as HTMLInputElement).checked;
    let path = "Congratulator/api/birthdaydate";

    if (checked) {
      path = path.concat("/coming");
    }

    this.loadData(path);
  }

  private loadData(path: string) {
    this.http.get<BirthdayDateCollection>(path).subscribe(result => {
      this.birthdayDates = result.birthdays;
    }, error => console.error(error));
  }
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
