import { async, ComponentFixture, TestBed } from "@angular/core/testing";
import { FeedbackDashComponent } from "./feedback-dash.component";
import { MaterialModule } from "../../material/material/material.module";
import { MatTableModule } from "@angular/material";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { BackendApiService } from "../service/backend-api.service";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";

describe("FeedbackDashComponent", () => {
  let component: FeedbackDashComponent;
  let fixture: ComponentFixture<FeedbackDashComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        MaterialModule,
        ReactiveFormsModule,
        FormsModule,
        HttpClientModule,
        BrowserAnimationsModule,
        MatTableModule,
        RouterModule.forRoot([])
      ],
      declarations: [FeedbackDashComponent],
      providers: [HttpClientModule, BackendApiService]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FeedbackDashComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
