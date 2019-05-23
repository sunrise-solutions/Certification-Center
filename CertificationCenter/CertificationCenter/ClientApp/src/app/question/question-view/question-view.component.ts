import { Component, Inject, ViewEncapsulation, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Question } from '../Models/Question';
import { API_BASE_URL } from '../../shared/shared.module';
import { NotificationsService } from 'angular2-notifications';

@Component({
  selector: 'app-question-view-component',
  templateUrl: './question-view.component.html',
  encapsulation: ViewEncapsulation.None
})
export class QuestionViewComponent implements OnInit{
  id = 0;

  courses: Question[] = [];

  constructor(
    private http: HttpClient, private ntf: NotificationsService
  ) {}

  ngOnInit() {
    this.loadQuestion();
  }

  loadQuestion() {
    this.http.get('http://localhost:55683/api/Course')
    .subscribe(
      (data: Question[])=> { 
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
  
}
