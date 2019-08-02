import { Component, OnInit, Input } from '@angular/core';
import { environment } from '@env/environment';

const lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque ut feugiat metus. Praesent non tortor congue metus pharetra auctor et.";

@Component({
  selector: 'app-contact-section',
  templateUrl: './contact-section.component.html',
  styleUrls: ['./contact-section.component.scss']
})
export class ContactSectionComponent implements OnInit {
  @Input()
  phone: string;
  @Input()
  email: string;
  
  description: String = lorem;

  constructor() { }

  ngOnInit() {
  }

}
