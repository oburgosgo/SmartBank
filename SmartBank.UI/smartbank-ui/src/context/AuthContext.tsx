import { createContext, ReactNode, useState } from "react";
import { SuccessAuthResponse } from "../interfaces/AuthResponse";
import { loginAPI, registerAPI } from "../services/AuthService";
import { SignUpRequest } from "../interfaces/SignUpRequest";

type AuthContextType = {
    isAuthenticaded: boolean,
    accessToken: string | null,
    login: (username: string, password: string) => Promise<SuccessAuthResponse>,
    logout: () => void,
    register: (signUpRequest: SignUpRequest) => Promise<boolean>
};

export const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({ children }: { children: ReactNode }) => {

    const [auth, setAuth] = useState<SuccessAuthResponse | null>(null);

    const login = async (username: string, password: string) => {
        const response = await loginAPI(username, password);

        setAuth(response);

        return response;
    };

    const register = async (signUpRequest: SignUpRequest) => {
        const response = await registerAPI(signUpRequest);

        return response;
    }

    const logout = () => {
        // setAccessToken("");
    };

    return (
        <AuthContext.Provider value={{
            isAuthenticaded: !!auth,
            accessToken: auth?.accessToken ?? null,
            login,
            logout,
            register,
        }}> {children}</AuthContext.Provider >
    );
};