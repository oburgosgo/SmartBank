import axios from "axios";

const AUTH_API_URL = import.meta.env.VITE_AUTH_API_URL;

export async function loginAPI(username: string, password: string) {

    const params = new URLSearchParams();
    params.append("grant_type", "password");
    params.append("client_id", import.meta.env.VITE_AUTH_CLIENT_ID_API);
    params.append("client_secret", "secret");
    params.append("username", username);
    params.append("password", password);
    params.append("scope", import.meta.env.VITE_AUTH_SCOPE_API);

    console.log(AUTH_API_URL);
    const response = await axios.post(`${AUTH_API_URL}connect/token`, params, {
        headers: {
            "Content-Type": "application/x-www-form-urlencoded"
        }
    });

    return response.data;
}