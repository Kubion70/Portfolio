import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeMainTopSectionComponent } from './home-main-top-section.component';

describe('HomeMainTopSectionComponent', () => {
  let component: HomeMainTopSectionComponent;
  let fixture: ComponentFixture<HomeMainTopSectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HomeMainTopSectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeMainTopSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
