import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegNotAttendedComponent } from './reg-notattended.component';
import { MaterialModule } from "../../../material/material/material.module";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { ActivatedRoute } from "@angular/router";
import { FormBuilder } from '@angular/forms';
import { BackendApiService } from '../../service/backend-api.service';
import { RouterModule } from '@angular/router';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';


describe('RegNotAttendedComponent', () => {
  let component: RegNotAttendedComponent;
  let fixture: ComponentFixture<RegNotAttendedComponent>;
  const formBuilder: FormBuilder = new FormBuilder();
  beforeEach(async(() => {
    TestBed.configureTestingModule({
        imports: [
            MaterialModule,
            ReactiveFormsModule,
            FormsModule,
            HttpClientModule,
            BrowserAnimationsModule, 
    
            RouterModule.forRoot([]), 
       ],
       providers: [HttpClientModule,BackendApiService],
      declarations: [ RegNotAttendedComponent ]
      
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegNotAttendedComponent);
    component = fixture.componentInstance;
    //component.eventName="TestEvent";
    fixture.detectChanges();
  });
 
  it('should create', () => {
   
    expect(component).toBeTruthy();

  });
});
