import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Feedbackmodel } from "../feedbackmodel/feedbackmodel.module";

@Injectable({
  providedIn: "root"
})
export class BackendApiService {
  constructor(private http: HttpClient) {}

  private url: string = "https://localhost:44327/api/";

  public idToken;

  getEvent(urlEvent: string) {
    return this.http.get(this.url + urlEvent);
  }

  addFeedback(urlValue: string, feedBackObject: Object) {
    return this.http.post(this.url + urlValue, feedBackObject);
  }

  getAllFeedback(){    
    this.idToken = localStorage.getItem("id_token");
    const headers = new HttpHeaders({      
      'Authorization': 'Bearer ' + this.idToken
    });    
    return this.http.get((this.url + "feedback"), { headers: headers });
  }

  userLogin(urlValue: string, userObject: Object){    
    return this.http.post(this.url + urlValue, userObject);
  }

  getAllEvents(){    
    this.idToken = localStorage.getItem("id_token");
    const headers = new HttpHeaders({      
      'Authorization': 'Bearer ' + this.idToken
    });    
    return this.http.get((this.url + "events"), { headers: headers });
  }
}
