import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { AppData } from '../base/app-data';
import { Bug } from './bug';

@Injectable({
  providedIn: 'root'
})
export class BugService {

  constructor(private http: HttpClient) { }

  createBug(bug: Bug) {
    let url = `${ AppData.appSettings.serviceBaseUrl }/bug/`;
    return this.http.post<any>(url, bug).subscribe(
          (data) => {
            alert('ooo');
            alert(JSON.stringify(data));
            // login successful if there's a jwt token in the response
            //return result.userInfo;
            },
          (error) => { alert(error); } // error path
        );
  }

  createBug2(bug: Bug): Observable<number> {
    let url = `${ AppData.appSettings.serviceBaseUrl }/bug/`;
    return this.http.post<number>(url, bug);
  }
}
