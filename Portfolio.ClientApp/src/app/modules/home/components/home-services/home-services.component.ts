import { Component, OnInit } from '@angular/core';
import { ServiceItem } from '@shared/models';

const lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque ut feugiat metus. Praesent non tortor congue metus pharetra auctor et.";

@Component({
  selector: 'app-home-services',
  templateUrl: './home-services.component.html',
  styleUrls: ['./home-services.component.scss']
})
export class HomeServicesComponent implements OnInit {

  services: ServiceItem[] = [
    {
      Icon: "public",
      Title: "Website",
      Description: lorem
    },
    {
      Icon: "business",
      Title: "Web Application",
      Description: lorem
    },
    {
      Icon: "desktop_windows",
      Title: "Desktop",
      Description: lorem
    },
    {
      Icon: "smartphone",
      Title: "Mobile",
      Description: lorem
    },
    {
      Icon: "question_answer",
      Title: "Consulting",
      Description: lorem
    },
    {
      Icon: "build",
      Title: "Maintanance",
      Description: lorem
    }
  ];

  constructor() { }

  ngOnInit() {
  }

}
