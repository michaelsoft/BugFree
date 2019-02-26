import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { AppData } from './app-data';
import { AuthenticationResults } from './authenticationResult';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    constructor(private http: HttpClient) { }

    login(username: string, password: string) {
        let url = `${ AppData.appSettings.serviceBaseUrl }/account/authenticate`;
        return this.http.post<any>(url, { "UserName": username, "Password": password, "RememberMe": true })
            .pipe(map(authResult => {
                alert(JSON.stringify(authResult));
                // login successful if there's a jwt token in the response
                if (authResult && authResult.result == AuthenticationResults.Succeeded && authResult.user) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify(authResult.user));
                }

                return authResult.user;
            }));
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
    }
}