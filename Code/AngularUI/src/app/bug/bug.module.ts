import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgZorroAntdModule, NZ_I18N, en_US } from 'ng-zorro-antd';

import { BugListComponent } from './bug-list/bug-list.component';
import { BugDetailComponent } from './bug-detail/bug-detail.component';

@NgModule({
  declarations: [BugListComponent, BugDetailComponent],
  imports: [
    CommonModule,
    NgZorroAntdModule
  ],
  exports: [
    BugListComponent,
    BugDetailComponent
  ]
})
export class BugModule { }
