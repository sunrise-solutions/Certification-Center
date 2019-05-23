import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_BASE_URL } from '../../shared/shared.module';
import { Router } from '@angular/router';
import { Question } from '../Models/Question';
import { NotificationsService } from 'angular2-notifications';

@Component({
  selector: 'app-question-create-component',
  templateUrl: './question-create.component.html'
})

export class QuestionCreateComponent {

  constructor(
    private http: HttpClient, private ntf: NotificationsService
  ) { }

  public course: Question = new Question();
  public courseName = "";
  public qualification = 0;

  public createCourse() {
      if (this.isValidLength(this.courseName) && this.isEmpty(this.courseName) && this.isNumber(this.qualification))
      {
        // this.course.name = this.courseName;
        // console.log(this.course.name);
        // this.course.qualification = this.qualification;
        // console.log(this.course.qualification);
        // const body = {Name: this.courseName, Qualification: this.qualification};
        // console.log(body);
        // return this.http.post('http://localhost:55683//api/Course/CreateCourse', body).subscribe(
        //   () => {console.log("success");
        //     this.ntf.success('Успешно', 'Направление добавлено');},
        //     error => {
        //       this.ntf.error('Ошибка', 'Направление не добавлено');
        //       return console.log(error);
        //     }
        // );
        this.ntf.success('Успешно', 'Вопрос добавлен');
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

