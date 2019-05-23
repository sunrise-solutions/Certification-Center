import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCheckboxModule, MatInputModule, MatFormFieldModule, MatButtonModule, MatCardModule } from '@angular/material';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  imports: [
    CommonModule,
    MatInputModule,
    MatFormFieldModule,
    MatCheckboxModule,
    MatButtonModule,
    MatCardModule
  ],
  declarations: [],
  exports: [
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatCheckboxModule,
    MatButtonModule,
    MatCardModule
  ]
})
export class MaterialModule {
  static forRoot() {
    return {
      ngModule: MaterialModule
    };
  }
}
