import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { SecurityService } from './security.service';
import { AuthenticationResult } from './authenticationResult';
import { User } from './user';

import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AuthenticationService } from './authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';

  @Input() userName: string = "mlau";
  @Input() password: string = "123";
  @Output() authenticated = new EventEmitter<User>();
  authResult: AuthenticationResult;

  // constructor(private securityService: SecurityService) { }

  // ngOnInit() {
  //   this.authResult = new AuthenticationResult();
  // }

  // authenticate(): void {
  //   this.authResult = this.securityService.authenticate(this.userName, this.password);
  //   if (this.authResult.result) {
  //     let user = new User();
  //     user.userName = this.userName;
  //     this.authenticated.emit(user);
  //   }
  // }

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService) { }

  ngOnInit() {
    this.authResult = new AuthenticationResult();

    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    // reset login status
    this.authenticationService.logout();

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }

  onSubmit() {
    // alert('Y');
    this.submitted = true;

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true;
    this.authenticationService.login(this.f.username.value, this.f.password.value)
      .pipe(first())
      .subscribe(
        data => {
          alert('Y' + JSON.stringify(data));
          this.router.navigate([this.returnUrl]);
        },
        error => {
          this.error = error;
          this.loading = false;
        });
  }
}
