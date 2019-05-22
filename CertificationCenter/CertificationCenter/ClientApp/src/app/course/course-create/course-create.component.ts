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
//'http://localhost:55683//api/Course/CreateCourse'

