import { Component, OnInit } from '@angular/core';
import { Technology } from '@shared/models/technology.model';
import { TechKnownLevel } from '@shared/enums/tech-known-level.enum';
import { Opinion } from '@shared/models/opinion.model';

const lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque ut feugiat metus. Praesent non tortor congue metus pharetra auctor et.";

@Component({
  selector: 'app-about-me-section',
  templateUrl: './about-me-section.component.html',
  styleUrls: ['./about-me-section.component.scss']
})
export class AboutMeSectionComponent implements OnInit {

  description: String = lorem + ' ' + lorem;
  opinion: Opinion = {
    Content: lorem,
    Author: "John Doe",
    Website: "#",
    Position: "Developer",
    Github: "#",
    LinkedIn: "#"
  };

  technologies: Technology[] = [
    new Technology(".NET Core", TechKnownLevel.WellKnown),
    new Technology(".NET Core", TechKnownLevel.WellKnown),
    new Technology(".NET Core", TechKnownLevel.WellKnown),
    new Technology(".NET Core", TechKnownLevel.WellKnown),
    new Technology(".NET Core", TechKnownLevel.WellKnown),
    new Technology(".NET Core", TechKnownLevel.WellKnown),
    new Technology(".NET Core", TechKnownLevel.WellKnown),
    new Technology(".NET Core", TechKnownLevel.WellKnown),
    new Technology("Angular", TechKnownLevel.EnoughToWorkWith),
    new Technology("Angular", TechKnownLevel.EnoughToWorkWith),
    new Technology("Angular", TechKnownLevel.EnoughToWorkWith),
    new Technology("Angular", TechKnownLevel.EnoughToWorkWith),
    new Technology("Angular", TechKnownLevel.EnoughToWorkWith),
    new Technology("Angular", TechKnownLevel.EnoughToWorkWith),
    new Technology("Angular", TechKnownLevel.EnoughToWorkWith),
    new Technology("Angular", TechKnownLevel.EnoughToWorkWith),
  ];

  wellKnownTechs: Technology[];
  enoughKnownTechs: Technology[];

  constructor() { }

  ngOnInit() {
    this.wellKnownTechs = this.technologies.filter(t => t.Level === TechKnownLevel.WellKnown);
    this.enoughKnownTechs = this.technologies.filter(t => t.Level === TechKnownLevel.EnoughToWorkWith);
  }
}
