import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BugFilterComponent } from './bug-filter.component';

describe('BugFilterComponent', () => {
  let component: BugFilterComponent;
  let fixture: ComponentFixture<BugFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BugFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BugFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
