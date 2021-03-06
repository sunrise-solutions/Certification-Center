import { Component, Inject, ViewEncapsulation, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Course } from '../Models/Course';
import { API_BASE_URL } from '../../shared/shared.module';
import { NotificationsService } from 'angular2-notifications';

@Component({
  selector: 'app-course-view-component',
  templateUrl: './course-view.component.html',
  encapsulation: ViewEncapsulation.None,
  styleUrls: ['../course.component.css']
})
export class CourseViewComponent implements OnInit{
  id = 0;

  courses: Course[] = [];

  constructor(
    private http: HttpClient, private ntf: NotificationsService
  ) {}

  ngOnInit() {
    this.loadCourses();
  }

  loadCourses() {
    this.http.get('http://localhost:55683/api/Course')
    .subscribe(
      (data: Course[])=> { 
        this.courses = data;
        console.log(data); // для проверки приходящих данных
        console.log(this.courses); // в консоли
   }, (error) => { console.log('an error occured!'); console.log(error);}
    );
  }

  saveToXML()
  {
    this.http.get('http://localhost:55683/api/Course/xml')
    .subscribe(
      (result: boolean)=> { 
        if (result) 
        {
          this.ntf.success('Успешно', 'Данные сохранены в файл course.xml');
        }
        else{
          this.ntf.error('Ошибка', 'Данные могут быть сохранены');
        }
        console.log(result); // в консоли
   }, (error) => { console.log('an error occured!'); console.log(error);}
    );
  }

  saveToXLS() {
    this.http.get('http://localhost:55683/api/Course/xls')
      .subscribe(
        (result: boolean) => {
          if (result) {
            this.ntf.success('Успешно', 'Данные сохранены в файл course.xls');
          }
          else {
            this.ntf.error('Ошибка', 'Данные могут быть сохранены');
          }
          console.log(result); // в консоли
        }, (error) => { console.log('an error occured!'); console.log(error); }
      );
  }
  
}
