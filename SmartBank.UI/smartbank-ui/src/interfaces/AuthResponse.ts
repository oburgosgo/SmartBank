export interface SuccessAuthResponse {
    accessToken: string;
    expiresIn: number;
    tokenType: string;
}

export interface ErrorAuthResponse {
    error: string;
    errorDescription: string;
}
