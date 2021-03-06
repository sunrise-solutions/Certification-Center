import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_BASE_URL } from '../../shared/shared.module';
import { Router } from '@angular/router';
import { Course } from '../Models/Course';
import { NotificationsService } from 'angular2-notifications';

@Component({
  selector: 'app-course-create-component',
  templateUrl: './course-create.component.html',
  styleUrls: ['../course.component.css']
})

export class CourseCreateComponent {

  constructor(
    private http: HttpClient, private ntf: NotificationsService
  ) { }

  public course: Course = new Course();
  public courseName = "";
  public qualification = 0;

  public createCourse() {
      if (this.isValidLength(this.courseName) && this.isEmpty(this.courseName) && this.isNumber(this.qualification))
      {
        this.course.name = this.courseName;
        console.log(this.course.name);
        this.course.qualification = this.qualification;
        console.log(this.course.qualification);
        const body = {Name: this.courseName, Qualification: this.qualification};
        console.log(body);
        return this.http.post('http://localhost:55683//api/Course', body).subscribe(
          () => {console.log("success");
            this.ntf.success('Успешно', 'Направление добавлено');},
            error => {
              this.ntf.error('Ошибка', 'Направление не добавлено');
              return console.log(error);
            }
        );
      }
      else {
        this.ntf.error('Ошибка', 'Данные неверные');
      }

  }

  isValidLength(str: String) {
    return str.length <= 100 ? true : false;
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
}
//'http://localhost:55683//api/Course/CreateCourse'

