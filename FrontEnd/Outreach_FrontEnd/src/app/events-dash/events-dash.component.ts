import { Component, OnInit } from '@angular/core';
import { BackendApiService } from "../service/backend-api.service";
import { Router } from "@angular/router";

@Component({
  selector: 'app-events-dash',
  templateUrl: './events-dash.component.html',
  styleUrls: ['./events-dash.component.styl']
})
export class EventsDashComponent implements OnInit {

  constructor(
    private _backEndService: BackendApiService,
    public router: Router
  ) { }

  public events;

  displayedColumns = [
    "eventid",
    "eventname",
    "beneficiaryname",
    "councilname",    
    "project"
  ];

  ngOnInit() {
    this._backEndService.getAllEvents().subscribe(
      data => {
        this.events = data;             
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
