import { Component, OnInit } from '@angular/core';
import { NotificationsService } from 'angular2-notifications';
import { HttpClient } from '@angular/common/http';
import { Course } from '../../course/Models/Course';
import { Question } from '../Models/Question';

@Component({
  selector: 'app-question-delete-component',
  templateUrl: './question-delete.component.html'
})
export class QuestionDeleteComponent implements OnInit{
  constructor(
    private http: HttpClient, private ntf: NotificationsService
  ) { }

  public coursesAll: Course[] = [];
  public topicsAll: Question[] = [];
  public selected: Question;

  public name = "";
  public count = 0;

  ngOnInit() {
    this.http.get<Question[]>('http://localhost:55683/' + 'api/Question').subscribe((result: Question[]) => {
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

  public deleteQuestion() {
    if (this.isNumber(this.selected.id))
    {
      return this.http.delete('http://localhost:55683/api/Question/' + this.selected.id).subscribe(
        () => {console.log("success");
          this.ntf.success('Успешно', 'Тема удалена');},
          error => {
            this.ntf.error('Ошибка', 'Тема не удалена');
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
