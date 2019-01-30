import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuComponent } from './menu.component';
import { LoginInfoComponent } from './login-info.component';
import { FooterComponent } from './footer.component';
import { LoginComponent } from './login.component';

@NgModule({
  declarations: [MenuComponent, LoginInfoComponent, FooterComponent, LoginComponent],
  imports: [
    CommonModule
  ],
  exports: [ MenuComponent, LoginInfoComponent, FooterComponent, LoginComponent ]
})
export class BaseModule { }
