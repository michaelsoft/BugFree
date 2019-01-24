import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bug-list',
  templateUrl: './bug-list.component.html',
  styleUrls: ['./bug-list.component.css']
})
export class BugListComponent implements OnInit {

  dataSet = [
    {
      BugID    : '1',
      BugTittle   : 'Create shipment fails',
      CreatedBy    : 'Lily',
      CreatedOn: '2018-10-1',
      AssignedTo    : 'Michael',
      Status: 'Opened'
    },
    {
      BugID    : '2',
      BugTittle   : 'Download monitor fails',
      CreatedBy    : 'Sandy',
      CreatedOn: '2018-11-1',
      AssignedTo    : 'Skyline',
      Status: 'Fixing'
    },
    {
      BugID    : '3',
      BugTittle   : 'Import shipment fails',
      CreatedBy    : 'Janey',
      CreatedOn: '2018-10-2',
      AssignedTo    : 'Michael',
      Status: 'Opened'
    },
  ];

  constructor() { }

  ngOnInit() {
  }

}
