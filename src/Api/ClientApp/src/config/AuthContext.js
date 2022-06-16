import React, { useContext, useState } from "react";
import axiosInstance from "./Axios";

const AuthContext = React.createContext();

export function useAuth() {
    return useContext(AuthContext);
}

export function AuthProvider({ children }) {
    const [currentUser, setCurrentUser] = useState(null);
    const [loading, setLoading] = useState(false);

    function login(loginRequest) {
        setLoading(true);

        axiosInstance.post('auth', loginRequest)
            .then((response) => {
                setCurrentUser(response);
            }).finally(() => setLoading(false));
    }

    function logout() {
        setLoading(true);

        axiosInstance.get('auth')
            .then(() => {
                setCurrentUser(null);
            })
            .finally(() => setLoading(false));
    }

    const value = {
        currentUser,
        login, 
        logout
    }

    return (
        <AuthContext.Provider value={value}>
            {!loading && children}
        </AuthContext.Provider>
    )
}