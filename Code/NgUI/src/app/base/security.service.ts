import { Injectable } from '@angular/core';
import { AuthenticationResult } from './authenticationResult';

@Injectable({
  providedIn: 'root'
})
export class SecurityService {

  constructor() { }

  authenticate(userName:string, password:string): AuthenticationResult {
     let retVal = new AuthenticationResult();
     
     if (userName === "mlau" && password === "123") {
         retVal.result = true;
     }
     else
     {
         retVal.errorMessage = "Invalid user name or password.";
     }
     
     return retVal;
  }
}
