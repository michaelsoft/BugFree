import { NgModule } from '@angular/core';

import { TabsModule } from 'ngx-bootstrap/tabs';

import { CommonModule } from '@angular/common';
import { BugListComponent } from './bug-list.component';
import { BugDetailComponent } from './bug-detail.component';
import { BugSearchComponent } from './bug-search.component';
import { BugFilterComponent } from './bug-filter.component';


@NgModule({
  declarations: [BugListComponent, BugDetailComponent, BugSearchComponent, BugFilterComponent],
  imports: [
    TabsModule.forRoot(),
    CommonModule
  ],
  exports: [BugListComponent, BugDetailComponent, BugSearchComponent, BugFilterComponent],
})
export class BugModule { }
