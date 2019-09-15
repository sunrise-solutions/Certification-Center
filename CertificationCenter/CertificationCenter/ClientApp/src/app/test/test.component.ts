import { Component, Inject, ViewEncapsulation, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NotificationsService } from 'angular2-notifications';
import { Question } from '../question/Models/Question';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  encapsulation: ViewEncapsulation.None
})
export class TestComponent implements OnInit{
  id = 0;
  tests: Question[] = [];

  constructor(
    private http: HttpClient, private ntf: NotificationsService
  ) {}

  ngOnInit() {
    this.loadQuestion();
  }

  loadQuestion() {
    this.http.get('http://localhost:55683/api/Question/8')
    .subscribe(
      (data: Question[])=> { 
        this.tests = data;
        console.log(data); // для проверки приходящих данных
        console.log(this.tests); // в консоли
   }, (error) => { console.log('an error occured!'); console.log(error);}
    );
  }
  
}
