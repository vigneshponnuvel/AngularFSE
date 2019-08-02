import { Component, OnInit } from "@angular/core";
import { FormBuilder, NgForm, FormGroup } from "@angular/forms";
import { BackendApiService } from "../../service/backend-api.service";
import { Observable } from "rxjs";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-reg-notattended",
  templateUrl: "./reg-notattended.component.html",
  styleUrls: ["./reg-notattended.component.styl"]
})
export class RegNotAttendedComponent implements OnInit {
  feedbackForm: FormGroup;  

  eventName: string;
  eventID: string;
  associateID: number;
  urlEvent: string = "events/";
  urlFeedback: string = "feedback";

  public events;

  public feedBackObject = {};

  constructor(
    private _backEndService: BackendApiService,
    private route: ActivatedRoute,
    private fb: FormBuilder
  ) {
    this.feedbackForm = fb.group({
      Feedback: [null]
    });
  }

  onFormSubmit(form: NgForm) {
    this.feedBackObject = {
      Eventid: this.eventID,
      Associateid: +this.associateID,
      Feedbackcategory: "RegNotAttended",
      Mainfeedback: "NA",
      Optionalfeedback1: "NA",
      Optionalfeedback2: this.feedbackForm.value.Feedback,
      Associatestatus: "NA",
      Createddt: "07/03/2019"
    };

    this.addFeedback(this.urlFeedback, this.feedBackObject);

    alert("Thank you for providing your feedback.");
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {      
      this.eventID = params.get("id");
      this.associateID = +params.get("associate");
      this._backEndService.getEvent(this.urlEvent + this.eventID + '/' + this.associateID + '/2').subscribe(
        data => {
          this.events = data;
        },
        err => console.error(err),
        () => {
          this.eventName = this.events.eventname;
        }
      );
    });
  }

  addFeedback(urlValue: string, feedBackObject: Object) {
    this._backEndService.addFeedback(urlValue, feedBackObject).subscribe(
      data => {
        return true;
      },
      error => {
        console.error("Error saving feedback!");
        return Observable.throw(error);
      }
    );
  }
}
