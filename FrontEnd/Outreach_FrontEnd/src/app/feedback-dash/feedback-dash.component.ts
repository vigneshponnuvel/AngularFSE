import { Component, OnInit } from "@angular/core";
import { BackendApiService } from "../service/backend-api.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-feedback-dash",
  templateUrl: "./feedback-dash.component.html",
  styleUrls: ["./feedback-dash.component.styl"]
})
export class FeedbackDashComponent implements OnInit {
  constructor(
    private _backEndService: BackendApiService,
    public router: Router
  ) {}

  public feedback;

  displayedColumns = [
    "eventid",
    "feedbackcategory",
    "associateid",
    "mainfeedback",
    "optionalfeedback2"
  ];

  ngOnInit() {
    this._backEndService.getAllFeedback().subscribe(
      data => {
        this.feedback = data;        
      },
      err => {          
        if(err.statusText == "Unauthorized" && (localStorage.getItem("id_token") == null))
        {
          this.router.navigate(["error"]);
        }        
      },
      () => {}
    );
  }

  logOutUser() {
    localStorage.removeItem("id_token");
    this.router.navigate([""]);
  }
}
