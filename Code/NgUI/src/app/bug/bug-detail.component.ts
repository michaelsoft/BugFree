import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Bug } from './bug';
import { BugService } from './bug.service';

@Component({
  selector: 'app-bug-detail',
  templateUrl: './bug-detail.component.html',
  styleUrls: ['./bug-detail.component.css']
})
export class BugDetailComponent implements OnInit {
  // bugForm: FormGroup;
  loading = false;
  submitted = false;
  error = '';

  @Input() bug: Bug;

  constructor(private formBuilder: FormBuilder, private bugService: BugService) { 
    this.bug = new Bug();
  }

  ngOnInit() {
    // this.bugForm = this.formBuilder.group({
    //   tittle: ['', Validators.required],
    // });
  }

  save() {
    // bugForm.form.submit();
  }

  onSubmit() {
    alert('Bug:\n\n' + JSON.stringify(this.bug));

    this.bugService.createBug2(this.bug)
      .subscribe(
        (data) => alert(JSON.stringify(data)),
        (error) => alert(error)
      );
   
  }

  // onSubmit() {
  //   // alert('Y');
  //   this.submitted = true;

  //   // stop here if form is invalid
  //   if (this.bugForm.invalid) {
  //     return;
  //   }

  //   alert('Bug:\n\n' + JSON.stringify(this.bug));

  //   this.loading = true;

  //   this.bugService.createBug2(this.bug)
  //   .subscribe(
  //     (data) => alert(JSON.stringify(data)),
  //     error => {
  //       this.error = error;
  //       this.loading = false;
  //     }
  //   );

  // }

}
