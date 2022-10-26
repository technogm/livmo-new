import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { forgetPassword } from 'src/app/Models/forgot-password';
import { AuthService } from '../../../../Services/Auth.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {
  public forgotPasswordForm!: FormGroup
  public successMessage!: string;
  public errorMessage!: string;
  public showSuccess!: boolean;
  public showError!: boolean;
  constructor(private log: AuthService) { }
  ngOnInit(): void {
    this.forgotPasswordForm = new FormGroup({
      email: new FormControl("", [Validators.required])
    })
  }
  public validateControl = (controlName: string) => {
    return this.forgotPasswordForm.controls[controlName].invalid && this.forgotPasswordForm.controls[controlName].touched
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.forgotPasswordForm.controls[controlName].hasError(errorName)
  }
  public forgotPassword = (forgotPasswordFormValue: any) => {
    this.showError = this.showSuccess = false;
    const forgotPass = { ...forgotPasswordFormValue };
    const forgotPassDto: forgetPassword = {
      email: forgotPass.email,
      clientURI: 'http://localhost:4200/resetpassword'
    }
    this.log.forgotPassword('http://localhost:5000/api/ClientControllers/ForgotPassword',forgotPassDto)
    .subscribe(_ => {
      this.showSuccess = true;
      this.successMessage = 'The link has been sent, please check your email to reset your password.'
    },
    err => {
      this.showError = true;
      this.errorMessage = err;
    })
  }
}
