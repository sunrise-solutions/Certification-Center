import { Component, Inject, ViewEncapsulation, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Course } from '../../course/Models/Course';
import { API_BASE_URL } from '../../shared/shared.module';
import { Topic } from '../Models/Topic';

@Component({
  selector: 'app-topic-view-component',
  templateUrl: './topic-view.component.html',
  encapsulation: ViewEncapsulation.None
})
export class TopicViewComponent implements OnInit{
  id = 0;

  public topics: Topic[] = [];
  public courses: Course[] = [];

  constructor(
    private http: HttpClient,
  ) {}

  ngOnInit() {
    this.loadSpecialists();
  }

  loadSpecialists() {
    this.http.get('http://localhost:55683/api/Topic')
    .subscribe(
      (data: Topic[])=> { 
        this.topics = data;
        console.log(data); // для проверки приходящих данных
        console.log(this.topics); // в консоли
        for (let index = 0; index < data.length; index++) {
          this.courses.push(this.findFacility(this.topics[index].courseId));
        }
   }, (error) => { console.log('an error occured!'); console.log(error);}
    );
    console.log(this.courses);
  }

  findFacility(id: number)
  {
    var f = new Course();
    this.http.get<Course>('http://localhost:55683/api/Course/' + id).subscribe((result: Course) => {
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
  
}