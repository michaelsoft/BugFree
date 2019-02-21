export class AuthenticationResult {
    result: boolean = false;
    errorMessage: string = "";
    token = ""
}

export enum AuthenticationResults {
    Succeeded = 1,
    InvalidUserNameOrPassword,
    LockedOut,
    PasswordExpired,
    Default = InvalidUserNameOrPassword,
}