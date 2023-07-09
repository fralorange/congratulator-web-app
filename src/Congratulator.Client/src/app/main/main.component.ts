import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Sort, MatSortModule } from '@angular/material/sort';
import { BirthdayDate } from '../core/birthday-date.interface';
import { BirthdayDateCollection } from '../core/birthday-date-collection.interface';
import { first } from 'rxjs';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  private readonly _apiUrl = 'Congratulator/api/birthdaydate';
  public birthdayDates?: BirthdayDate[];
  public sortedDates?: BirthdayDate[];

  constructor(private _http: HttpClient) {
    this.loadData(this._apiUrl);
  }

  public loadData(path: string, callback?: () => void) {
    this._http.get<BirthdayDateCollection>(path).subscribe(result => {
      this.birthdayDates = result.birthdays;
      this.sortedDates = this.birthdayDates.slice();
      if (callback) {
        callback();
      }
    }, error => console.error(error));
  }

  public sortData(sort: Sort) {
    const data = this.birthdayDates?.slice();
    if (!sort.active || sort.direction === '') {
      this.sortedDates = data;
      return;
    }

    this.sortedDates = data?.sort((a, b) => {
      const isAsc = sort.direction === 'asc';
      switch (sort.active) {
        case 'id':
          return compare(a.id, b.id, isAsc);
        case 'firstName':
          return compare(a.firstName, b.firstName, isAsc);
        case 'lastName':
          return compare(a.lastName, b.lastName, isAsc);
        case 'birthDate':
          return compare(a.birthDate, b.birthDate, isAsc);
        default:
          return 0;
      }
    });
  }

  public onRadioboxchange(event: Event) {
    const option = (event.target as HTMLInputElement).value;
    let path = this._apiUrl;

    switch (option) {
      case 'all':
        this.loadData(path);
        break;
      case 'coming':
        this.loadData(path.concat("/coming"));
        break;
      case 'belated':
        this.loadData(path, () => {
          const today = new Date();
          this.birthdayDates = this.birthdayDates?.filter(date => {
            const birthDate = new Date(date.birthDate);
            birthDate.setFullYear(today.getFullYear())
            return birthDate < today;
          });
          this.sortedDates = this.birthdayDates?.slice();
        });
        break;
    }
  }

  public onButtonClick(id: number) {
    this._http.delete<void>(`${this._apiUrl}/${id}`).subscribe(() => {
      this.loadData(this._apiUrl);
    },
      error => {
        console.error(error);
        alert("Don't press 'Delete' button so fast");
      });
  }
}

function compare(a: number | string | Date, b: number | string | Date, isAsc: boolean) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
