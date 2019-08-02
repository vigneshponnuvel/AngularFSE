import { Component, OnInit } from "@angular/core";
import { BackendApiService } from "../service/backend-api.service";
import { FormBuilder, FormGroup, NgForm, Validators } from "@angular/forms";
import { Observable } from "rxjs";
import { Router } from "@angular/router";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.styl"]
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  public userObject = {};

  urlLogin: string = "login";

  public JWTString;

  loginError: boolean = false;

  constructor(
    private _backEndService: BackendApiService,
    private formLogin: FormBuilder,
    public router: Router
  ) {
    this.loginForm = formLogin.group({
      userID: ["", Validators.required],
      password: ["", Validators.required]
    });
  }

  onFormSubmit(form: NgForm) {
    this.userObject = {
      Username: this.loginForm.value.userID,
      Password: this.loginForm.value.password
    };

    if (
      this.loginForm.value.userID != "" &&
      this.loginForm.value.password != ""
    ) {
      this.loginUser(this.urlLogin, this.userObject);
    }
  }

  ngOnInit() {}

  loginUser(urlValue: string, userObject: Object) {
    this._backEndService.userLogin(urlValue, userObject).subscribe(
      data => {
        this.JWTString = data;
      },
      error => {
        if (error.statusText == "Unauthorized") {
          this.loginError = true;
        }
      },
      () => {
        this.setSession(this.JWTString);
        this.router.navigate(["feedbackAll"]);
      }
    );
  }

  private setSession(authResult) {
    localStorage.setItem("id_token", authResult.token);
  }
}
