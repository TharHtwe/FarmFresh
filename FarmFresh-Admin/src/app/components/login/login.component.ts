import { UserStoreService } from './../../services/user-store.service';
import { Router } from '@angular/router';
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
  isProcessing: boolean = false;

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router, private store: UserStoreService, private toast: NgToastService) {}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  onLogin() {
    if(this.loginForm.valid){
      this.isProcessing = true;
      this.authService.login(this.loginForm.value)
        .subscribe({
          next: (response: any) => {
            this.authService.storeToken(response.token);
            this.loginForm.reset();
            const tokenPayload = this.authService.decodeToken();
            this.store.setFullName(tokenPayload.name);
            this.isProcessing = false;
            this.router.navigate(['/'])
          },
          error: (err: any) => {
            this.toast.error({detail: "ERROR!", summary: err.error.message, duration: 5000});
            this.isProcessing = false;
            console.log(err)
          }
        })
    }else{
      ValidateForm.validateFormFields(this.loginForm);
      this.toast.error({detail: "ERROR!", summary: "Please fill required fields.", duration: 5000});
    }
  }
}
