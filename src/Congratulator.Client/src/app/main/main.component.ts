import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { BirthdayDate } from '../core/birthday-date.interface';
import { BirthdayDateCollection } from '../core/birthday-date-collection.interface';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  private readonly _apiUrl = 'Congratulator/api/birthdaydate';
  public birthdayDates?: BirthdayDate[];

  constructor(private _http: HttpClient) {
    this.loadData(this._apiUrl);
  }

  public loadData(path: string) {
    this._http.get<BirthdayDateCollection>(path).subscribe(result => {
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
    this._http.delete<void>(`${this._apiUrl}/${id}`).subscribe(() => {
      this.loadData(this._apiUrl);
    },
      error => {
        console.error(error);
        alert("Don't press 'Delete' button so fast");
      });
  }
}
