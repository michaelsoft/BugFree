import { Component, OnInit, Input } from '@angular/core';

import { Bug } from './bug';

@Component({
  selector: 'app-bug-detail',
  templateUrl: './bug-detail.component.html',
  styleUrls: ['./bug-detail.component.css']
})
export class BugDetailComponent implements OnInit {

  @Input() bug: Bug;

  constructor() { 
    this.bug = new Bug();
  }

  ngOnInit() {
  }

  save() {
    alert('Success!\n\n' + JSON.stringify(this.bug));
   
  }

}
