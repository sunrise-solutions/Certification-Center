import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CourseCreateComponent } from './course/course-create/course-create.component';
import { CourseUpdateComponent } from './course/course-update/course-update.component';
import { CourseViewComponent } from './course/course-view/course-view.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SimpleNotificationsModule } from 'angular2-notifications';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { SpecialistCreateComponent } from './specialist/specialist-create/specialist-create.component';
import { SpecialistUpdateComponent } from './specialist/specialist-update/specialist-update.component';
import { SpecialistViewComponent } from './specialist/specialist-view/specialist-view.component';
import { TopicCreateComponent } from './topic/topic-create/topic-create.component';
import { TopicUpdateComponent } from './topic/topic-update/topic-update.component';
import { TopicViewComponent } from './topic/topic-view/topic-view.component';
import { TopicDeleteComponent } from './topic/topic-delete/topic-delete.component';
import { FooterComponent } from './footer/footer.component';
import { QuestionCreateComponent } from './question/question-create/question-create.component';
import { QuestionDeleteComponent } from './question/question-delete/question-delete.component';
import { QuestionViewComponent } from './question/question-view/question-view.component';
//import { MatSelectModule} from '@angular/material/select';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CourseCreateComponent,
    CourseUpdateComponent,
    CourseViewComponent,
    SpecialistCreateComponent,
    SpecialistUpdateComponent,
    SpecialistViewComponent,
    TopicCreateComponent,
    TopicUpdateComponent,
    TopicViewComponent,
    TopicDeleteComponent,
    FetchDataComponent,
    FooterComponent,
    QuestionCreateComponent,
    QuestionViewComponent,
    QuestionDeleteComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    NoopAnimationsModule,
    MaterialModule.forRoot(),
    //MatSelectModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'course/course-create', component: CourseCreateComponent },
      { path: 'course/course-update', component: CourseUpdateComponent },
      { path: 'course/course-view', component: CourseViewComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'specialist/specialist-create', component: SpecialistCreateComponent },
      { path: 'specialist/specialist-update', component: SpecialistUpdateComponent },
      { path: 'specialist/specialist-view', component: SpecialistViewComponent },
      { path: 'topic/topic-create', component: TopicCreateComponent },
      { path: 'topic/topic-update', component: TopicUpdateComponent },
      { path: 'topic/topic-view', component: TopicViewComponent },
      { path: 'topic/topic-delete', component: TopicDeleteComponent },
      { path: 'question/question-create', component: QuestionCreateComponent },
      { path: 'question/question-view', component: QuestionViewComponent },
      { path: 'question/question-delete', component: QuestionDeleteComponent }
    ]),
    SimpleNotificationsModule.forRoot({
      timeOut: 5000,
      showProgressBar: false
    })
  ],
  providers: [],
  exports: [
    FooterComponent,
    //Error404PageComponent,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
