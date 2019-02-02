import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { SecurityService } from './security.service';
import { AuthenticationResult } from './authenticationResult';
import { User } from './user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  @Input() userName: string;
  @Input() password: string;
  @Output() authenticated = new EventEmitter<User>();
  authResult: AuthenticationResult;

  constructor(private securityService: SecurityService) { }

  ngOnInit() {
    this.authResult = new AuthenticationResult();
  }

  authenticate(): void {
     this.authResult = this.securityService.authenticate(this.userName, this.password);
     if (this.authResult.result) {
       let user = new User();
       user.userName = this.userName;
       this.authenticated.emit(user);
     }
     //console.log(authResult.result);
  }

}
