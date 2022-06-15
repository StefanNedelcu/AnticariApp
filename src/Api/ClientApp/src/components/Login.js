import React, { useEffect } from 'react';
import axiosInstance from "../config/Axios";

const Login = () => {

    useEffect(() => {
        axiosInstance.post('auth', {
            email: "stefan.nedelcu@mailinator.com",
            password: "123456"
        });
    }, []);

    return (
        <div>
            Logheaza-te ba
        </div>
    );
}

export default Login;
