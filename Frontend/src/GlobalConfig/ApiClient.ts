import axios from 'axios'
import { useTokenStore } from '@/stores/TokenStore'
const http = axios.create({
  baseURL: 'https://localhost:7134/api/'
})

http.interceptors.request.use(
  (config) => {
    config.headers.Authorization = `Bearer ${useTokenStore().getToken()?.replace(/"/g, '')}`
    return config
  },
  (error) => {
    return Promise.reject(error)
  }
)
http.interceptors.response.use(
  (response) => {
    return Promise.resolve(response)
  },
  (error) => {
    return Promise.reject(error)
  }
)
export { http }
