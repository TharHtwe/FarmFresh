import { Router } from '@angular/router';
import { AuthService } from './../../services/auth.service';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import ValidateForm from 'src/app/helpers/validateForm';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {
  signupForm!: FormGroup;
  isProcessing: boolean = false;

  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router, private toast: NgToastService) {}

  ngOnInit(): void {
    this.signupForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  onSignUp() {
    if(this.signupForm.valid){
      this.isProcessing = true;
      this.auth.signUp(this.signupForm)
        .subscribe({
          next: (response: any) => {
            this.signupForm.reset();
            this.isProcessing = false;
            this.router.navigate(['login']);
          },
          error: (err: any) => {
            this.isProcessing = false;
            this.toast.error({detail: "ERROR!", summary: err.error.message, duration: 5000});
            console.log(err);
          }
        })
    }else{
      ValidateForm.validateFormFields(this.signupForm);
      this.toast.error({detail: "ERROR!", summary: "Please fill required fields.", duration: 5000});
    }
  }
}
