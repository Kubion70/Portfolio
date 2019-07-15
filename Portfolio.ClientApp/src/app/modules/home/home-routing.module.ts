import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeMainComponent } from './pages';

const routes: Routes = [
  {
    path: '',
    component: HomeMainComponent,
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
