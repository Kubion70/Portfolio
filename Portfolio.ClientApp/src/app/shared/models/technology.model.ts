import { TechKnownLevel } from '@shared/enums/tech-known-level.enum';

export class Technology {
  Name: String;
  Level: TechKnownLevel

  constructor(name: String, level: TechKnownLevel){
    this.Name = name;
    this.Level = level;
  }
}
