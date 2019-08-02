import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainPageService } from './services';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  providers: [
    MainPageService
  ],
  imports: [
    CommonModule,
    HttpClientModule
  ]
})
export class CoreModule { }
