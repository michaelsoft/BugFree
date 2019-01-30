import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuComponent } from './menu.component';
import { LoginInfoComponent } from './login-info.component';
import { FooterComponent } from './footer.component';

@NgModule({
  declarations: [MenuComponent, LoginInfoComponent, FooterComponent],
  imports: [
    CommonModule
  ],
  exports: [ MenuComponent, LoginInfoComponent, FooterComponent ]
})
export class BaseModule { }
