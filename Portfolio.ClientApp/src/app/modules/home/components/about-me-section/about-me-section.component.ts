import { Component, OnInit, Input } from '@angular/core';
import { TechKnownLevel } from '@core/enums';
import { Opinion, Technology } from '@core/models';

const lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque ut feugiat metus. Praesent non tortor congue metus pharetra auctor et.";

@Component({
  selector: 'app-about-me-section',
  templateUrl: './about-me-section.component.html',
  styleUrls: ['./about-me-section.component.scss']
})
export class AboutMeSectionComponent implements OnInit {
  @Input()
  description: String;
  @Input()
  technologies: Technology[];

  opinion: Opinion = {
    Content: lorem,
    Author: "John Doe",
    Website: "#",
    Position: "Developer",
    Github: "#",
    LinkedIn: "#"
  };

  wellKnownTechs: Technology[];
  enoughKnownTechs: Technology[];

  constructor() { }

  ngOnInit() {
    this.wellKnownTechs = this.technologies.filter(t => t.KnownLevel === TechKnownLevel.WellKnown);
    this.enoughKnownTechs = this.technologies.filter(t => t.KnownLevel === TechKnownLevel.EnoughToWorkWith);
  }
}
