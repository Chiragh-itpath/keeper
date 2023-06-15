import axios from "axios";
import { useCookies } from "vue3-cookies";

const { cookies } = useCookies()
// let token = "";
// if (cookies.get("token") != null)
//     token = cookies.get("token")
// const headers = {
//     "Authorization": `Bearer ${token}`,
// };
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