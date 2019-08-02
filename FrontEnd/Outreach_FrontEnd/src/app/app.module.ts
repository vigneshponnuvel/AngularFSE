import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import {
  FormGroup,
  FormControl,
  ReactiveFormsModule,
  FormsModule
} from "@angular/forms";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { RegCancelComponent } from "./Register-AndCancel/reg-cancel/reg-cancel.component";
import { RegNotAttendedComponent } from "./Register-NotAttended/reg-notattended/reg-notattended.component";
import { MaterialModule } from "../material/material/material.module";
import { RegAttendedComponent } from "./Register-AndAttended/reg-attended/reg-attended.component";
import { HttpClientModule } from "@angular/common/http";
import { BackendApiService } from "./service/backend-api.service";
import { FeedbackDashComponent } from './feedback-dash/feedback-dash.component';
import { MatTableModule } from '@angular/material';
import { LoginComponent } from './login/login.component';
import { ErrorComponent } from './error/error.component';
import { EventsDashComponent } from './events-dash/events-dash.component';
import { MatMenuModule} from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material';

@NgModule({
  declarations: [
    AppComponent,
    RegCancelComponent,
    RegNotAttendedComponent,
    RegAttendedComponent,
    FeedbackDashComponent,
    LoginComponent,
    ErrorComponent,
    EventsDashComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MaterialModule,    
    HttpClientModule,
    FormsModule,
    MatTableModule,
    MatMenuModule,
    MatPaginatorModule
  ],
  providers: [BackendApiService],
  bootstrap: [AppComponent]
})
export class AppModule {}
