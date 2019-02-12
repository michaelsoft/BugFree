import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { TabsModule } from 'ngx-bootstrap/tabs';

import { BaseModule } from '../base/base.module';

import { BugListComponent } from './bug-list.component';
import { BugDetailComponent } from './bug-detail.component';
import { BugSearchComponent } from './bug-search.component';
import { BugFilterComponent } from './bug-filter.component';
import { BugHomeComponent } from './bug-home.component';


@NgModule({
  declarations: [BugListComponent, BugDetailComponent, BugSearchComponent, BugFilterComponent, BugHomeComponent],
  imports: [
    TabsModule.forRoot(),
    CommonModule,
    FormsModule,
    BaseModule
  ],
  exports: [BugListComponent, BugDetailComponent, BugSearchComponent, BugFilterComponent, BugHomeComponent],
})
export class BugModule { }
