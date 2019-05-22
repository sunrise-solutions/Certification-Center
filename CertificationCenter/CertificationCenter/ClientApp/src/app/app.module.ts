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
//import { MatSelectModule} from '@angular/material/select';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CourseCreateComponent,
    CourseUpdateComponent,
    CourseViewComponent,
    FetchDataComponent
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
    ]),
    SimpleNotificationsModule.forRoot({
      timeOut: 5000,
      showProgressBar: false
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
