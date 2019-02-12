import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuComponent } from './menu.component';
import { LoginInfoComponent } from './login-info.component';
import { FooterComponent } from './footer.component';
import { LoginComponent } from './login.component';
import { FormsModule } from '@angular/forms';
import { AlertModule } from 'ngx-bootstrap/alert';
import { ReactiveFormsModule }    from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './jwt.interceptor';
import { ErrorInterceptor } from './error.interceptor';
import { fakeBackendProvider } from './fake-backend';
import { HomeComponent } from './home.component';

@NgModule({
  declarations: [MenuComponent, LoginInfoComponent, FooterComponent, LoginComponent, HomeComponent],
  imports: [
    CommonModule,
    FormsModule,
    AlertModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  exports: [ MenuComponent, LoginInfoComponent, FooterComponent, LoginComponent ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },

    // provider used to create fake backend
    // fakeBackendProvider
],
})
export class BaseModule { }
