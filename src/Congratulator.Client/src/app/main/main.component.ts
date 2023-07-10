import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Sort } from '@angular/material/sort';
import { BirthdayDate } from '../core/birthday-date.interface';
import { BirthdayDateCollection } from '../core/birthday-date-collection.interface';
import { Image } from '../core/image.interface';
import { ImageCollection } from '../core/image-collection.interface';
import { setTime } from 'ngx-bootstrap/chronos/utils/date-setters';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  private readonly _apiUrl = 'Congratulator/api/';
  public birthdayDates?: BirthdayDate[];
  public sortedDates?: BirthdayDate[];
  public images?: Image[];
  public imageSrc: string = '';
  public imageVisible = false;
  public imageCoords: [number, number] = [0, 0];
  public timer: any;

  constructor(private _http: HttpClient) {
    this.loadData('', true);
  }

  public loadData(attribute: string = '', image: boolean = false, callback?: () => void) {
    this._http.get<BirthdayDateCollection>(this._apiUrl.concat(`birthdaydate/${attribute}`)).subscribe(result => {
      this.birthdayDates = result.birthdays;
      this.sortedDates = this.birthdayDates.slice();
      if (callback) {
        callback();
      }
    }, error => console.error(error));
    if (image) {
      this._http.get<ImageCollection>(this._apiUrl.concat(`image/${attribute}`)).subscribe(result => {
        this.images = result.images;
      }, error => console.error(error));
    }
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

    switch (option) {
      case 'all':
        this.loadData();
        break;
      case 'coming':
        this.loadData("/coming");
        break;
      case 'belated':
        this.loadData(undefined, false, () => {
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
    this._http.delete<void>(`${this._apiUrl}birthdaydate/${id}`).subscribe(() => {
      this.loadData();
      this.imageVisible = false;
    },
      error => {
        console.error(error);
        alert("Don't press 'Delete' button so fast");
      });
  }

  public onMouseEnter(event: MouseEvent, id: number) {
    this.timer = setTimeout(() => {
      let imageString = this.images?.find(img => img.birthdayId == id)?.img;
      let dataUrl = 'data:image/jpeg;base64,' + imageString;
      this.imageSrc = dataUrl;

      this.imageCoords[0] = event.clientX;
      this.imageCoords[1] = event.clientY;
      this.imageVisible = true;
    }, 500);
  }

  public onMouseLeave() {
    clearTimeout(this.timer);
    this.imageVisible = false;
  }

  public onMouseMove(event: MouseEvent) {
    this.imageCoords[0] = event.clientX;
    this.imageCoords[1] = event.clientY;
  }
}

function compare(a: number | string | Date, b: number | string | Date, isAsc: boolean) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
