import axios from 'axios'
import { useTokenStore } from '@/stores/TokenStore'
import { useUserStore } from "@/stores/UserStore";
import { storeToRefs } from 'pinia';


const http = axios.create({
  baseURL: 'https://localhost:7134/api/'
})

http.interceptors.request.use(
  (config) => {
    let {isLoading} = storeToRefs(useUserStore())
    isLoading.value=true
    config.headers.Authorization = `Bearer ${useTokenStore().getToken()?.replace(/"/g, '')}`
    return config
  },
  (error) => {
    let {isLoading} = storeToRefs(useUserStore())
    isLoading.value=false
    return Promise.reject(error)
  }
)
http.interceptors.response.use(
  (response) => {
    let {isLoading} = storeToRefs(useUserStore())
    isLoading.value=false
    return Promise.resolve(response)
  },
  (error) => {
    let {isLoading} = storeToRefs(useUserStore())
    isLoading.value=false
    return Promise.reject(error)
  }
)
export { http }
