import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeMainComponent } from './pages';
import { SharedModule } from '@shared/shared.module';
import { HomeMainTopSectionComponent } from './components/home-main-top-section/home-main-top-section.component';
import { HomeServicesComponent } from './components/home-services/home-services.component';
import { AboutMeSectionComponent } from './components/about-me-section/about-me-section.component';
import { ContactSectionComponent } from './components/contact-section/contact-section.component';
import { ContactFormComponent } from './components/contact-form/contact-form.component';
import { FooterComponent } from './components/footer/footer.component';

@NgModule({
  declarations: [
    HomeMainComponent,
    HomeMainTopSectionComponent,
    HomeServicesComponent,
    AboutMeSectionComponent,
    ContactSectionComponent,
    ContactFormComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    SharedModule
  ]
})
export class HomeModule { }
