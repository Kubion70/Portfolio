import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainPageService } from './services';
import { HttpClientModule } from '@angular/common/http';
import { MainPageResolve } from './resolves';

@NgModule({
  providers: [
    MainPageService,
    MainPageResolve
  ],
  imports: [
    CommonModule,
    HttpClientModule
  ]
})
export class CoreModule { }
