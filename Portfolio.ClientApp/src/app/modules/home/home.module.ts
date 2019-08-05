import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeMainComponent } from './pages';
import { HomeMainTopSectionComponent } from './components/home-main-top-section/home-main-top-section.component';
import { HomeServicesComponent } from './components/home-services/home-services.component';
import { AboutMeSectionComponent } from './components/about-me-section/about-me-section.component';
import { ContactSectionComponent } from './components/contact-section/contact-section.component';
import { ContactFormComponent } from './components/contact-form/contact-form.component';
import { FooterComponent } from './components/footer/footer.component';
import { SharedModule } from '@shared/shared.module';
import { ErrorSnackBarComponent, SuccessSnackBarComponent } from '@shared/components';

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
  ],
  entryComponents: [
    ErrorSnackBarComponent,
    SuccessSnackBarComponent
  ]
})
export class HomeModule { }
