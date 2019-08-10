import { Component, OnInit } from '@angular/core';
import { MainPageData } from '@core/models';
import { ActivatedRoute } from '@angular/router';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-home-main',
  templateUrl: './home-main.component.html',
  styleUrls: ['./home-main.component.scss']
})
export class HomeMainComponent implements OnInit {

  mainPageData: MainPageData;

  constructor(
    private route: ActivatedRoute,
    private titleService: Title
  ) { }

  ngOnInit() {
    this.route.data.subscribe((data: { mainPageData: MainPageData }) => {
      this.mainPageData = data.mainPageData;
      this.titleService.setTitle(this.mainPageData.title + ' - ' + this.mainPageData.subTitle);
    });
  }
}
