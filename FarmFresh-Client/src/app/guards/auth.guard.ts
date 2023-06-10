import { AuthService } from './../services/auth.service';
import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';

export const authGuard: CanActivateFn = (route, state) => {
  if(inject(AuthService).isLoggedIn()){
    return true;
  }else{
    inject(Router).navigate(['/login'])
    return false;
  }
};
