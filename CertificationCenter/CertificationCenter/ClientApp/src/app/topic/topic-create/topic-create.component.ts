import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_BASE_URL } from '../../shared/shared.module';
import { Router } from '@angular/router';
import { Course } from '../../course/Models/Course';
import { NotificationsService } from 'angular2-notifications';
import { Topic } from '../Models/Topic';

@Component({
  selector: 'app-topic-create-component',
  templateUrl: './topic-create.component.html'
})

export class TopicCreateComponent implements OnInit{

  constructor(
    private http: HttpClient, private ntf: NotificationsService
  ) { }

  public topic: Topic = new Topic();
  public courses: Course[] = [];
  public id = 0;
  public selected: Course;

  public name = "";
  public count = 0;

  ngOnInit() {
    this.http.get<Course[]>('http://localhost:55683/' + 'api/Course').subscribe((result: Course[]) => {
      this.courses = result;
    console.log(result);},
      error => console.error(error));
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

  public createTopic() {
    if (this.isValidLength(this.name) && this.isEmpty(this.name) 
    && this.isNumber(this.count) && this.isNumber(this.selected.id))
    {
      this.topic.name = this.name;
      this.topic.countOfQuestions = this.count;
      this.topic.courseId = this.selected.id;
      console.log(this.topic);
      return this.http.post('http://localhost:55683/api/Topic', this.topic).subscribe(
        () => {console.log("success");
          this.ntf.success('Успешно', 'Тема добавлена');},
          error => {
            this.ntf.error('Ошибка', 'Тема не добавлена');
            return console.log(error);
          }
      );
    }
    else {
      this.ntf.error('Ошибка', 'Данные не верные');
    }

}
  
}
//'http://localhost:55683//api/Specialist/CreateSpecialist'

