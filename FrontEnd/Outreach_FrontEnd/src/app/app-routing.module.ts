import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { RegAttendedComponent } from "./Register-AndAttended/reg-attended/reg-attended.component";
import { RegCancelComponent } from "./Register-AndCancel/reg-cancel/reg-cancel.component";
import { RegNotAttendedComponent } from "./Register-NotAttended/reg-notattended/reg-notattended.component";
import { FeedbackDashComponent } from "./feedback-dash/feedback-dash.component";
import { EventsDashComponent } from "./events-dash/events-dash.component";
import { LoginComponent } from "./login/login.component";
import { ErrorComponent } from "./error/error.component";

const routes: Routes = [
  { path: "feedbackAttn/:id/:associate", component: RegAttendedComponent },
  { path: "feedbackNotAtn/:id/:associate", component: RegNotAttendedComponent },
  { path: "feedbackCan/:id/:associate", component: RegCancelComponent },
  { path: "feedbackAll", component: FeedbackDashComponent },
  { path: "eventsAll", component: EventsDashComponent },
  { path: "error", component: ErrorComponent },
  { path: "", component: LoginComponent },
  { path: "login", component: LoginComponent },
  { path: "**", component: ErrorComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
