import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgZorroAntdModule, NZ_I18N, en_US } from 'ng-zorro-antd';

import { MenuComponent } from './menu/menu.component';

@NgModule({
  declarations: [ MenuComponent ],
  imports: [
    CommonModule,
    NgZorroAntdModule
  ],
  exports: [
    MenuComponent
  ]
})
export class BaseModule { }
