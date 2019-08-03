import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeMainComponent } from './pages';
import { MainPageResolve } from '@core/resolves';

const routes: Routes = [
  {
    path: '',
    component: HomeMainComponent,
    pathMatch: 'full',
    resolve: {
      mainPageData: MainPageResolve
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
