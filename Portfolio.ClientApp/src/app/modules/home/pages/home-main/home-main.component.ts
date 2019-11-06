import {Component, OnInit} from '@angular/core';
import {MainPageData} from '@core/models';
import {ActivatedRoute} from '@angular/router';
import {Title} from '@angular/platform-browser';
import {TranslateService} from '@ngx-translate/core';
import {SupportedCulture} from '@core/enums/supported-culture.enum';

@Component({
  selector: 'app-home-main',
  templateUrl: './home-main.component.html',
  styleUrls: ['./home-main.component.scss']
})
export class HomeMainComponent implements OnInit {

  mainPageData: MainPageData;
  isEnglish: boolean;

  constructor(
    private route: ActivatedRoute,
    private titleService: Title,
    private translate: TranslateService
  ) { }

  ngOnInit() {
    this.isEnglish = this.translate.currentLang === SupportedCulture.EN;

    this.route.data.subscribe((data: { mainPageData: MainPageData }) => {
      this.mainPageData = data.mainPageData;
      this.titleService.setTitle(this.mainPageData.title + ' - ' + this.mainPageData.subTitle);
    });
  }

  scroll(id: string) {
    const el = document.getElementById(id);
    el.scrollIntoView({block: 'start', behavior: 'smooth'});
    el.scrollTop += 32;
  }

  languageChange() {
    this.translate.use(this.isEnglish ? SupportedCulture.PL : SupportedCulture.EN);
    this.isEnglish = !this.isEnglish;
  }
}
