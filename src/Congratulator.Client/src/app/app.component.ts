import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  private readonly _apiUrl = 'Congratulator/api/birthdaydate';
  public birthdayDates?: BirthdayDate[];

  constructor(private http: HttpClient) {
    this.loadData(this._apiUrl);
  }

  title = 'Congratulator.Client';

  private loadData(path: string) {
    this.http.get<BirthdayDateCollection>(path).subscribe(result => {
      this.birthdayDates = result.birthdays;
    }, error => console.error(error));
  }

  onCheckboxChange(event: Event) {
    const checked = (event.target as HTMLInputElement).checked;
    let path = this._apiUrl;

    if (checked) {
      path = path.concat("/coming");
    }

    this.loadData(path);
  }

  onButtonClick(id: number) {
    this.http.delete<void>(`${this._apiUrl}/${id}`).subscribe(() =>
    {
      this.loadData(this._apiUrl);
    },
    error => {
      console.error(error);
      alert("Don't press 'Delete' button so fast");
    });
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
