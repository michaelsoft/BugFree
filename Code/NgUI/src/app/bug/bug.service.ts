import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { AppData } from '../base/app-data';
import { Bug } from './bug';

@Injectable({
  providedIn: 'root'
})
export class BugService {

  constructor(private http: HttpClient) { }

  // createBug(bug: Bug): Observable<number> {
  //   let url = `${ AppData.appSettings.serviceBaseUrl }/bug/`;
  //   return this.http.post<number>(url, bug);
  // }

  createBug(bug: Bug): Observable<HttpResponse<number>> {
    let url = `${ AppData.appSettings.serviceBaseUrl }/bug/`;
    return this.http.post<number>(url, bug, {observe:'response'} );
  }
}
