import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RegAttendedComponent } from './reg-attended.component';
import { MaterialModule } from "../../../material/material/material.module";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { ActivatedRoute } from "@angular/router";
import { FormBuilder } from '@angular/forms';
import { BackendApiService } from '../../service/backend-api.service';
import { RouterModule } from '@angular/router';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

describe('RegAttendedComponent', () => {
  let component: RegAttendedComponent;
  let fixture: ComponentFixture<RegAttendedComponent>;
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
      declarations: [ RegAttendedComponent ],
      providers: [HttpClientModule,BackendApiService],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegAttendedComponent);
    component = fixture.componentInstance;
    
    fixture.detectChanges();
  });

  // function updateform()
  // {
  //   component.feedbackForm = formBuilder.group(
  //     {
      
  //       eventName:"sdg",

  //     });
  // }

  it('should create', () => {
   
    expect(component).toBeTruthy();
  });
});
