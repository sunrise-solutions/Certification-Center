import { Component, Inject, ViewEncapsulation, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Course } from '../Models/Course';
import { API_BASE_URL } from '../../shared/shared.module';

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
    private http: HttpClient,
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
  
}
