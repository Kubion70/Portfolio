import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { MainPageService } from '@core/services';
import { Injectable } from '@angular/core';
import { MainPageData } from '@core/models';

@Injectable()
export class MainPageResolve implements Resolve<MainPageData> {
  constructor (
    private mainPageService: MainPageService,
    private router: Router
  ) { }

  async resolve(route: ActivatedRouteSnapshot): Promise<MainPageData> {
    const result = await this.mainPageService.getMainPageData().toPromise();
    return result;
  }
}