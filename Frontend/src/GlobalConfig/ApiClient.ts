import axios from "axios";
import { useTokenStore } from '@/stores/TokenStore';
export const http = axios.create({
    baseURL: 'https://localhost:7134/api/',
});

http.interceptors.request.use(
    config => {
        config.headers['Authorization'] = `Bearer ${useTokenStore().getToken()}`;
        return config;
    },
    error => {
        return Promise.reject(error);
    }
);