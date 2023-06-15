import axios from "axios";
import { useCookies } from "vue3-cookies";

const { cookies } = useCookies()
export const http = axios.create({
    baseURL: 'https://localhost:7134/api/',
});

http.interceptors.request.use(
    config => {
      config.headers['Authorization'] = `Bearer ${cookies.get("token")}`;
          return config;
      },
      error => {
          return Promise.reject(error);
      }
  );