import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { environment } from '@env/environment';

@Component({
  selector: 'app-home-main-top-section',
  templateUrl: './home-main-top-section.component.html',
  styleUrls: ['./home-main-top-section.component.scss']
})
export class HomeMainTopSectionComponent implements OnInit {
  @Input()
  title: string;
  @Input()
  subTitle: string;
  @Input()
  topDescription: string;
  @Input()
  topImageUrl: string;

  @Output()
  detailsClick = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

}
