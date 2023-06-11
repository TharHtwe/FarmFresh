import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseApiUrl: string = environment.baseApiUrl;
  private userPayload: any;
  private loggedIn = new BehaviorSubject<boolean>(false);

  constructor(private http: HttpClient) {
    this.userPayload = this.decodeToken();
   }

  login(loginObj: any): any {
    return this.http.post<any>(this.baseApiUrl + '/api/admin/authenticate', loginObj);
  }

  logOut() {
    localStorage.clear();
    this.loggedIn.next(false);
  }

  storeToken(token: string) {
    localStorage.setItem('adminToken', token);
    this.loggedIn.next(true)
  }

  getToken() {
    return localStorage.getItem('adminToken');
  }

  isLoggedIn() {
    return !!localStorage.getItem('adminToken')
  }

  decodeToken() {
    const jwtHelper = new JwtHelperService();
    const token = this.getToken()!;

    return jwtHelper.decodeToken(token);
  }

  getFullName() {
    if(this.userPayload){
      return this.userPayload.name;
    }
  }
}
