import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_BASE_URL } from '../../shared/shared.module';
import { Router } from '@angular/router';
import { Course } from '../Models/Course';

@Component({
  selector: 'app-course-create-component',
  templateUrl: './course-create.component.html'
})

export class CourseCreateComponent {

  constructor(
    private http: HttpClient
  ) { }

  public course: Course = new Course();
  public courseName = "";
  public qualification = 0;

  public createCourse() {
      this.course.Name = this.courseName;
      console.log(this.course.Name);
      this.course.Qualification = this.qualification;
      console.log(this.course.Qualification);
      const body = {Name: this.courseName, Qualification: this.qualification};
      console.log(body);
      return this.http.post('http://localhost:55683//api/Course/CreateCourse', body).subscribe(
          error => {
            return console.log(error);
          }
      );

  }
}
//'http://localhost:55683//api/Course/CreateCourse'

