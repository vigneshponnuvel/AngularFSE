import { Component, OnInit } from "@angular/core";
import { BackendApiService } from "../service/backend-api.service";
import { FormBuilder, FormGroup, NgForm, Validators } from "@angular/forms";
import { Observable } from "rxjs";
import { Router } from '@angular/router';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.styl']
})
export class ErrorComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
