import { Component, OnInit } from "@angular/core";
import { FormBuilder, NgForm, FormGroup, Validators } from "@angular/forms";
import { BackendApiService } from "../../service/backend-api.service";
import { Observable } from "rxjs";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-reg-attended",
  templateUrl: "./reg-attended.component.html",
  styleUrls: ["./reg-attended.component.styl"]
})
export class RegAttendedComponent implements OnInit {
  feedbackForm: FormGroup;

  eventName: string;
  eventID: string;
  associateID: number;
  mainFeedback: string;
  radioValue: string = "";
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
      Feedbackcategory: "RegAttended",
      Mainfeedback: this.mainFeedback,
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
      this._backEndService.getEvent(this.urlEvent + this.eventID + '/' + this.associateID + '/1').subscribe(
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

  feedbackChoose(mainFeedback: string) {
    this.mainFeedback = mainFeedback;
  }
}
