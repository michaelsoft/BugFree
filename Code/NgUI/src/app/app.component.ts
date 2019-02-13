import { Component } from '@angular/core';
import { ConfigurationService } from './base/configuration.service';
import { AppData } from './base/app-data';
import { AppSettings } from './base/appSettings';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Bug Free';

  constructor(private configService: ConfigurationService) { }

  ngOnInit() {
    this.configService.getAppSettings()
       .subscribe((data: AppSettings) => { 
           AppData.appSettings = data 
          //  alert(JSON.stringify(data));
       });
  }
}
