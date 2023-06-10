import { AuthService } from './../../services/auth.service';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import ValidateForm from 'src/app/helpers/validateForm';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm!: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService, private toast: NgToastService) {}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  onLogin() {
    if(this.loginForm.valid){
      this.authService.login(this.loginForm.value)
        .subscribe({
          next: (response: any) => {
            console.log(response)
          },
          error: (err: any) => {
            this.toast.error({detail: 'ERROR!', summary: err.error.message, duration: 5000});
            console.log(err)
          }
        })
    }else{
      ValidateForm.validateFormFields(this.loginForm);
      this.toast.error({detail: 'ERROR!', summary: 'Please fill required fields.', duration: 5000});
    }
  }
}
