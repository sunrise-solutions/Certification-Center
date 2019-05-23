import { Component, OnInit } from '@angular/core';
import { NotificationsService } from 'angular2-notifications';
import { HttpClient } from '@angular/common/http';
import { Course } from '../../course/Models/Course';
import { Topic } from '../Models/Topic';

@Component({
  selector: 'app-topic-update-component',
  templateUrl: './topic-update.component.html'
})
export class TopicUpdateComponent implements OnInit{
  constructor(
    private http: HttpClient, private ntf: NotificationsService
  ) { }

  public topic: Topic = new Topic();
  public courses: Course[] = [];
  public coursesAll: Course[] = [];
  public topicsAll: Topic[] = [];
  public id = 0;
  public selected: Topic;
  public selectedCourse: Course;

  public name = "";
  public count = 0;

  ngOnInit() {
    this.http.get<Course[]>('http://localhost:55683/' + 'api/Course').subscribe((result: Course[]) => {
      this.courses = result;
    console.log(result);},
      error => console.error(error));

    this.http.get<Topic[]>('http://localhost:55683/' + 'api/Topic').subscribe((result: Topic[]) => {
      this.topicsAll = result;
      for (let index = 0; index < result.length; index++) {
        this.coursesAll.push(this.findCourse(result[index].courseId));
      }
    console.log(result);},
      error => console.error(error));  
  }

  findCourse(id: number)
  {
    var f = new Course();
    this.http.get('http://localhost:55683/api/Course/' + id).subscribe((result: Course) => {
      console.log(result);
      f.name = result.name;
      f.qualification = result.qualification;
      f.id = result.id;
    },
      error => {
        return console.log(error);
      }
     );
    
     return f;
  }

  public updateTopic() {
    if (this.isValidLength(this.name) && this.isEmpty(this.name) 
    && this.isNumber(this.count) && this.isNumber(this.selected.id))
    {
      this.topic.name = this.name;
      this.topic.countOfQuestions = this.count;
      this.topic.courseId = this.selected.id;
      console.log(this.topic);
      return this.http.put('http://localhost:55683/api/Topic', this.topic).subscribe(
        () => {console.log("success");
          this.ntf.success('Успешно', 'Тема обновлена');},
          error => {
            this.ntf.error('Ошибка', 'Тема не обновлена');
            return console.log(error);
          }
      );
    }
    else {
      this.ntf.error('Ошибка', 'Данные не верные');
    }

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
