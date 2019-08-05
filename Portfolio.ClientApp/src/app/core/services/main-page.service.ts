import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { MainPageData, MailContact } from '@core/models';
import { Observable } from 'rxjs';
import { environment } from '@env/environment';

const API_URL = environment.apiServer.url;

@Injectable()
export class MainPageService {
  constructor(private http: HttpClient) { }

  getMainPageData(): Observable<MainPageData> {
    return this.http.get<MainPageData>(API_URL + 'MainPage/GetMainPageData');
  }

  sendContactingMail(model: MailContact): Observable<HttpResponse<object>> {
    return this.http.post(API_URL + 'MainPage/SendContactingMail', model, {
      observe: 'response'
    });
  }
}