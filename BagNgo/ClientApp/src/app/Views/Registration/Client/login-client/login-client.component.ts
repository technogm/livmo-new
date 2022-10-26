import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { AuthService } from "../../../../Services/Auth.service";
import {
  FormBuilder,
  FormGroup,
  Validators,
} from "@angular/forms";
@Component({
  selector: "app-login-client",
  templateUrl: "./login-client.component.html",
  styleUrls: ["./login-client.component.css"],
})
export class LoginClientComponent implements OnInit {
  form!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private securityService: AuthService,
    private route: Router,
    private activeRoute: Router,

  ) {}

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      Email: [
        "",
        {
          validators: [Validators.required, Validators.email],
        },
      ],
      Password: [
        "",
        {
          validators: [Validators.required],
        },
      ],
      rememberMe: false,
    });
  }


  login() {
    this.securityService.login(this.form.value).subscribe(
      (data) => {
        console.log("Console data value : ", data);

        this.securityService.saveToken(data);
        // check role
        this.route.navigate(["Dashboard-client"]);
      },
      (err) => {
        console.log("Error ", err);
        this.route.navigate(["login"]);
      } /*error => this.errors = parseWebAPIErrors(error)*/
    );
  }
  routing(path: any) {
    this.activeRoute.navigate([path])
  }
}
