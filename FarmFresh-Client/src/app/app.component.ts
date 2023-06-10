import { UserStoreService } from './services/user-store.service';
import { NavigationEnd, Router } from '@angular/router';
import { AuthService } from './services/auth.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public loginPage: boolean = false;
  public fullName: string = "";
  title = 'FarmFresh-Client';
  constructor(private auth: AuthService, private router: Router, private store: UserStoreService) {}

  ngOnInit(): void {
    this.store.getFullName()
      .subscribe(val => {
        let fullNameFromToken = this.auth.getFullName();
        this.fullName = val || fullNameFromToken;
      });
    this.router.events.subscribe((event: any) => {
      if (event instanceof NavigationEnd) {
        if (event.url === '/login') {
          this.loginPage= true;
        } else {
          this.loginPage= false;
        }
      }
    });
  }

  logOut() {
    this.auth.logOut()
    this.router.navigate(['login'])
  }
}
