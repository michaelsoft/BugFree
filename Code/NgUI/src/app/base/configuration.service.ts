import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from './appSettings';


@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {

  private configUrl = "assets/appSettings.json";
  loaded = false;
  constructor(private http: HttpClient) { }

  getAppSettings(){
     return this.http.get<AppSettings>(this.configUrl);
  }

}
