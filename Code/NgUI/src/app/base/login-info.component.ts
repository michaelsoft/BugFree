import { Component, OnInit } from '@angular/core';
import { AppData } from './app-data';
import { Router } from '@angular/router';
import { User } from './user';
import { AuthenticationService } from './authentication.service';

@Component({
  selector: 'app-login-info',
  templateUrl: './login-info.component.html',
  styleUrls: ['./login-info.component.css']
})
export class LoginInfoComponent implements OnInit {
  user: User;

  constructor(private router: Router, private authenticationService: AuthenticationService) { 
  }

  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem('currentUser'));;
  }

  onLogout() {
    this.authenticationService.logout();
    this.router.navigate(["/login"]);
  }

}
