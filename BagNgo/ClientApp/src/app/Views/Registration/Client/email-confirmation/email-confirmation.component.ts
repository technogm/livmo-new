import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../../../../Services/Auth.service';

@Component({
  selector: 'app-email-confirmation',
  templateUrl: './email-confirmation.component.html',
  styleUrls: ['./email-confirmation.component.scss']
})
export class EmailConfirmationComponent implements OnInit {
  public showSuccess!: boolean
  public showError!: boolean
  public errorMessage!: string
  constructor(private _authService: AuthService, private _route: ActivatedRoute) { }
  ngOnInit(): void {
    this.confirmEmail();
  }
  private confirmEmail = () => {
    this.showError = this.showSuccess = false;
    const token = this._route.snapshot.queryParams['token'];
    const email = this._route.snapshot.queryParams['email'];
    console.log(token);
    this._authService.confirmEmail(token, email)
    .subscribe({next :_ => {
      this.showSuccess = true;
    },
    error : error => {
      this.showError = true;
      this.errorMessage = "Something wrong try again";
    }})
  }
}
