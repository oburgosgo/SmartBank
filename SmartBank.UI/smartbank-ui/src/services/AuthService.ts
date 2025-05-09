import axios from "axios";
import { parse } from "valibot";
import { TokenResponseSchema } from "../schemas/auth.schema";
import { SuccessAuthResponse } from "../interfaces/AuthResponse";

const AUTH_API_URL = import.meta.env.VITE_AUTH_API_URL;

export async function loginAPI(username: string, password: string): Promise<SuccessAuthResponse> {

    const params = new URLSearchParams();
    params.append("grant_type", "password");
    params.append("client_id", import.meta.env.VITE_AUTH_CLIENT_ID_API);
    params.append("client_secret", "secret");
    params.append("username", username);
    params.append("password", password);
    params.append("scope", import.meta.env.VITE_AUTH_SCOPE_API);

    try {
        const tokenResponse = await axios.post(`${AUTH_API_URL}connect/token`, params, {
            headers: {
                "Content-Type": "application/x-www-form-urlencoded"
            }
        });

        const response = parse(TokenResponseSchema, tokenResponse.data)

        return {
            accessToken: response.access_token,
            expiresIn: response.expires_in,
            tokenType: response.token_type
        };
    }
    catch (error) {

        if (axios.isAxiosError(error) && error.response?.data?.error === "invalid_grant") {
            throw new Error("Invalid username or password");
        }
        else {
            throw new Error("Login failed. Please try again.");
        }
    }
}