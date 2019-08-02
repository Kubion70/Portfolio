import { Component, OnInit, Input } from '@angular/core';
import { OfferItem } from '@core/models';

const lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque ut feugiat metus. Praesent non tortor congue metus pharetra auctor et.";

@Component({
  selector: 'app-home-services',
  templateUrl: './home-services.component.html',
  styleUrls: ['./home-services.component.scss']
})
export class HomeServicesComponent implements OnInit {
  @Input()
  services: OfferItem[];

  constructor() { }

  ngOnInit() {
  }

}
