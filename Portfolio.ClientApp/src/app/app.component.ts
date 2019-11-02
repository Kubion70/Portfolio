import { Component } from '@angular/core';
import { SupportedCulture } from '@core/enums/supported-culture.enum';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'portfolio-client-app';

  constructor(private translate: TranslateService) {
    this.translate.addLangs([SupportedCulture.EN, SupportedCulture.PL]);
    this.translate.setDefaultLang(SupportedCulture.EN);

    const browserLang = translate.getBrowserLang();
    const lang: SupportedCulture = SupportedCulture[browserLang.toUpperCase()];

    this.translate.use(lang != null ? lang : SupportedCulture.EN);
  }
}
