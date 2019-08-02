import { Component, OnInit } from '@angular/core';
import { MainPageData } from '@core/models';
import { MainPageService } from '@core/services';

@Component({
  selector: 'app-home-main',
  templateUrl: './home-main.component.html',
  styleUrls: ['./home-main.component.scss']
})
export class HomeMainComponent implements OnInit {

  mainPageData: MainPageData;

  constructor(
    private mainPageService: MainPageService
  ) { }

  ngOnInit() {
    this.mainPageService.getMainPageData().toPromise().then(result => {
      this.mainPageData = result;
    });
  }

}
