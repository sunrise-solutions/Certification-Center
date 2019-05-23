import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_BASE_URL } from '../../shared/shared.module';
import { Router } from '@angular/router';
import { Specialist } from '../Models/Specialist';
import { NotificationsService } from 'angular2-notifications';
import { Facility } from '../Models/Facility';

@Component({
  selector: 'app-specialist-create-component',
  templateUrl: './specialist-create.component.html',
  styleUrls: ['../specialist.component.css']
})

export class SpecialistCreateComponent implements OnInit{

  constructor(
    private http: HttpClient, private ntf: NotificationsService
  ) { }

  public specialist: Specialist = new Specialist();
  public facilities: Facility[] = [];
  public id = 0;
  public selected: Facility;

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
  }

  isValidLength(str: String) {
    return str.length <= 45 ? true : false;
  }

  isEmpty(str: String) {
    return str.length != 0 ? true : false;
  }

  isNumber(num: any) {
    // if (num === undefined) 
    // {
    //   return false;
    // }
    var value = parseInt(num, 10);
    return value !== NaN && num !== undefined;
  }

  public createSpecialist() {
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
      this.specialist.healthFacilitiesFacultyId = this.selected.id;
      console.log(this.specialist);
      return this.http.post('http://localhost:55683//api/Specialist', this.specialist).subscribe(
        () => {console.log("success");
          this.ntf.success('Успешно', 'Специалист зарегистрирован');},
          error => {
            this.ntf.error('Ошибка', 'Специалист не зарегистрирован');
            return console.log(error);
          }
      );
    }
    else {
      this.ntf.error('Ошибка', 'Данные неверные');
    }

}
  
}
//'http://localhost:55683//api/Specialist/CreateSpecialist'

