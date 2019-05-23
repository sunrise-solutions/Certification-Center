import { Component, OnInit } from '@angular/core';
import { NotificationsService } from 'angular2-notifications';
import { HttpClient } from '@angular/common/http';
import { Course } from '../Models/Course';

@Component({
  selector: 'app-course-update-component',
  templateUrl: './course-update.component.html',
  styleUrls: ['../course.component.css']
})
export class CourseUpdateComponent implements OnInit{
  constructor(
    private http: HttpClient, private ntf: NotificationsService
  ) { }

  public course: Course = new Course();
  public coursesAll: Course[] = [];
  public coursesNames: string[] = [];
  public courseName = "";
  public qualification = 0;
  public id = 0;
  public selected: Course;

  ngOnInit() {
    this.http.get<Course[]>('http://localhost:55683/' + 'api/Course').subscribe((result: Course[]) => {
      this.coursesAll = result;
      for (let index = 0; index < result.length; index++) {
        this.coursesNames.push(result[index].name);
        console.log(this.coursesNames[index]);
      }
    console.log(this.coursesAll);},
      error => console.error(error));
  }

  public updateCourse() {
    if (this.isValidLength(this.courseName) && this.isEmpty(this.courseName) && this.isNumber(this.qualification))
    {
      this.course.name = this.courseName;
      console.log(this.course.name);
      this.course.qualification = this.qualification;
      console.log(this.course.qualification);
      const body = {Name: this.courseName, Qualification: this.qualification};
      console.log(this.selected.id);
      return this.http.put('http://localhost:55683/api/Course/'+ this.selected.id, body).subscribe(
        () => {console.log("success");
          this.ntf.success('Успешно', 'Направление обновлено');},
          error => {
            this.ntf.error('Ошибка', 'Направление не обновлено');
            return console.log(error);
          }
      );
    } else {
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
