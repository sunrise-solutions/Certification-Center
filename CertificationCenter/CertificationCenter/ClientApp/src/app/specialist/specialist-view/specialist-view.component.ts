import { Component, Inject, ViewEncapsulation, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Specialist } from '../Models/Specialist';
import { API_BASE_URL } from '../../shared/shared.module';
import { Facility } from '../Models/Facility';

@Component({
  selector: 'app-specialist-view-component',
  templateUrl: './specialist-view.component.html',
  encapsulation: ViewEncapsulation.None
})
export class SpecialistViewComponent implements OnInit{
  id = 0;

  specialists: Specialist[] = [];
  facilities: Facility[] = [];

  constructor(
    private http: HttpClient,
  ) {}

  ngOnInit() {
    this.loadSpecialists();
  }

  loadSpecialists() {
    this.http.get('http://localhost:55683/api/Specialist')
    .subscribe(
      (data: Specialist[])=> { 
        this.specialists = data;
        console.log(data); // для проверки приходящих данных
        console.log(this.specialists); // в консоли
        for (let index = 0; index < data.length; index++) {
          this.facilities.push(this.findFacility(data[index].healthFacilitiesFacultyId));
        }
   }, (error) => { console.log('an error occured!'); console.log(error);}
    );
  }

  findFacility(id: number)
  {
    let facility: Facility;
    this.http.get('http://localhost:55683/api/HealthFacility/' + id).subscribe((result: Facility) => {
      facility = result;
      console.log(result);
    },
      error => {
        return console.log(error);
      }
     );
    return facility;

  }
  
}