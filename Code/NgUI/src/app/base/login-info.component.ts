import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { User } from './user';

@Component({
  selector: 'app-login-info',
  templateUrl: './login-info.component.html',
  styleUrls: ['./login-info.component.css']
})
export class LoginInfoComponent implements OnInit {

  @Input() user: User;
  @Output() onLogout = new EventEmitter(); 

  constructor() { }

  ngOnInit() {
  }

  fireLogout(): void {
    this.onLogout.emit("");
  }

}
