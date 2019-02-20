import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { AppData } from './app-data';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    constructor(private http: HttpClient) { }

    login(username: string, password: string) {
        let url = `${ AppData.appSettings.serviceBaseUrl }/account/authenticate`;
        return this.http.post<any>(url, { username, password })
            .pipe(map(authResult => {
                // login successful if there's a jwt token in the response
                if (authResult && authResult.Result == 1 && authResult.UserInfo) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify(authResult.UserInfo));
                }

                return authResult.UserInfo;
            }));
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
    }
}