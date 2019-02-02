import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuComponent } from './menu.component';
import { LoginInfoComponent } from './login-info.component';
import { FooterComponent } from './footer.component';
import { LoginComponent } from './login.component';
import { FormsModule } from '@angular/forms';
import { AlertModule } from 'ngx-bootstrap/alert';

@NgModule({
  declarations: [MenuComponent, LoginInfoComponent, FooterComponent, LoginComponent],
  imports: [
    CommonModule,
    FormsModule,
    AlertModule
  ],
  exports: [ MenuComponent, LoginInfoComponent, FooterComponent, LoginComponent ]
})
export class BaseModule { }
