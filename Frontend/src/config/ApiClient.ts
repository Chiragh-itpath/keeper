import axios, { AxiosError } from 'axios'
import { storeToRefs } from 'pinia'
import { Uitlity, UserStore } from '@/stores'
import { getToken } from '@/Services/TokenService'
import { Colors } from '@/Models/enum'
import type { IResponse } from '@/Models/ResponseModel'

const http = axios.create({
    baseURL: 'https://localhost:7134/api/'
})

const loadingEffect = (arg: boolean): void => {
    const { Loading } = storeToRefs(Uitlity())
    Loading.value = arg
}
const navigateTologin = async () => {
    const { logout } = UserStore()
    logout()
}
const useToster = (message: string, color: Colors) => {
    const { makeToster } = Uitlity()
    makeToster(message, color)
}
http.interceptors.request.use((config) => {
    loadingEffect(true)
    config.headers.Authorization = `Bearer ${getToken()}`
    return config
})
http.interceptors.response.use(
    (ApiResponse): any => {
        loadingEffect(false)
        const { data }: { data: IResponse } = ApiResponse
        const { isSuccess, message } = data
        if (isSuccess) {
            if (message != null && message != '') {
                useToster(message, Colors.SUCCESS)
            }
        } else {
            if (message != null && message != '') {
                useToster(message, Colors.DANGER)
            }
        }
        return Promise.resolve(data.data)
    },
    (error: AxiosError<any>): Promise<null> => {
        loadingEffect(false)
        if (error.response?.status == 401) {
            navigateTologin()
            useToster('Your session is over Please login again', Colors.WARNING)
            return Promise.resolve(null)
        }
        if (error.code == 'ERR_NETWORK') {
            useToster('Server unavailable', Colors.DANGER)
        } else {
            useToster(error.response?.data.Message, Colors.DANGER)
        }
        return Promise.resolve(null)
    }
)
export { http }
