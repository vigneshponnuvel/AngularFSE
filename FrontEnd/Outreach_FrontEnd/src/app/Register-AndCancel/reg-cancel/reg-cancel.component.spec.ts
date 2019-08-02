import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegCancelComponent } from './reg-cancel.component';

xdescribe('RegCancelComponent', () => {
  let component: RegCancelComponent;
  let fixture: ComponentFixture<RegCancelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegCancelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegCancelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
