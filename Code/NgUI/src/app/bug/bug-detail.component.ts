import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Bug } from './bug';

@Component({
  selector: 'app-bug-detail',
  templateUrl: './bug-detail.component.html',
  styleUrls: ['./bug-detail.component.css']
})
export class BugDetailComponent implements OnInit {

  @Input() bug: Bug;
  // bugForm: FormGroup;

  constructor() { 
    this.bug = new Bug();
    // this.bugForm = new FormGroup();
  }

  ngOnInit() {
  }

  save() {
    // if (this.bugForm.valid) {
      alert('Success!');
    // }
    // else {
    //   alert('Error!');
    // }
    
  }

}
