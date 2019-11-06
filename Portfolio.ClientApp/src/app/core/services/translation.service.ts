import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateLoader } from '@ngx-translate/core';
import { SupportedCulture } from '@core/enums/supported-culture.enum';
import { Observable } from 'rxjs';

@Injectable()
export class TranslationService implements TranslateLoader {

    constructor(private http: HttpClient) { }

    getTranslation(culture: SupportedCulture): Observable<JSON> {
      return this.http.get<JSON>(`/assets/i18n/${culture}.json`);
    }
}
