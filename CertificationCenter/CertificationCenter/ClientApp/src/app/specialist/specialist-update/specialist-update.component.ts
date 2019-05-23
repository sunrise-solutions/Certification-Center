import { Component, OnInit } from '@angular/core';
import { NotificationsService } from 'angular2-notifications';
import { HttpClient } from '@angular/common/http';
import { Specialist } from '../Models/Specialist';
import { Facility } from '../Models/Facility';

@Component({
  selector: 'app-specialist-update-component',
  templateUrl: './specialist-update.component.html'
})
export class SpecialistUpdateComponent implements OnInit{
  constructor(
    private http: HttpClient, private ntf: NotificationsService
  ) { }

  public specialist: Specialist = new Specialist();
  public facilities: Facility[] = [];
  public sprcialistsAll: Specialist[] = [];
  public id = 0;
  public selected: Specialist;
  public selectedFacility: Facility;

  public lastName = "";
  public firstName = "";
  public middleName = "";
  public email = "";
  public passwordHash = "";

  ngOnInit() {
    this.http.get<Facility[]>('http://localhost:55683/' + 'api/HealthFacility').subscribe((result: Facility[]) => {
      this.facilities = result;
    console.log(result);},
      error => console.error(error));

    this.http.get<Specialist[]>('http://localhost:55683/' + 'api/Specialist').subscribe((result: Specialist[]) => {
      this.sprcialistsAll = result;
    console.log(result);},
      error => console.error(error));  
  }

  public updateSpecialist() {
    if (this.isValidLength(this.lastName) && this.isValidLength(this.firstName) && this.isValidLength(this.middleName) &&
    this.isValidLength(this.email) && this.isValidLength(this.passwordHash) && 
    this.isEmpty(this.lastName) && this.isEmpty(this.firstName) && this.isEmpty(this.middleName) &&
    this.isEmpty(this.email) && this.isEmpty(this.passwordHash) && this.isNumber(this.selected.id))
    {
      this.specialist.lastName = this.lastName;
      this.specialist.firstName = this.firstName;
      this.specialist.middleName = this.middleName;
      this.specialist.email = this.email;
      this.specialist.passwordHash = this.passwordHash;
      this.specialist.healthFacilitiesFacultyId = this.selectedFacility.id;
      console.log(this.specialist);
      return this.http.put('http://localhost:55683/api/Specialist/' + this.selected.id, this.specialist).subscribe(
        () => {console.log("success");
          this.ntf.success('Успешно', 'Специалист обновлен');},
          error => {
            this.ntf.error('Ошибка', 'Специалист не обновлен');
            return console.log(error);
          }
      );
    }
    else {
      this.ntf.error('Ошибка', 'Данные не верные');
    }

  }

  isValidLength(str: String) {
    return str.length <= 100 ? true : false;
  }

  isEmpty(str: String) {
    return str.length != 0 ? true : false;
  }

  isNumber(num: any) {
    var value = parseInt(num, 10);
    return value !== NaN && num !== undefined;
  }
}
