import { createContext, ReactNode, useState } from "react";

type AuthContextType = {
    isAuthenticaded: boolean,
    accessToken: string,
    login: (token: string) => void,
    logout: () => void
};

export const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({ children }: { children: ReactNode }) => {

    const [accessToken, setAccessToken] = useState("");

    const login = (token: string) => {
        setAccessToken(token);
    };

    const logout = () => {
        setAccessToken("");
    };

    return (
        <AuthContext.Provider value={{
            isAuthenticaded: !!accessToken, accessToken, login, logout
        }}>{children}</AuthContext.Provider>
    );
};