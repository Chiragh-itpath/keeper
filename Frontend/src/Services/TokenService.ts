import type { IToken } from '@/Models/TokenModel'

const setToken = (token: IToken): void => {
    const date = new Date()
    date.setHours(date.getHours() + 1)
    document.cookie = `token=${JSON.stringify(token)};expires=${date} ; path=/;`
}
const removeToken = (): void => {
    document.cookie = `token=; expires=Thu, 01 Jan 1970 00:00:00 UTC;path=/;`
}
const getToken = (): string => {
    const cookies = document.cookie.split(';')
    for (const cookie of cookies) {
        const [cookieName, cookieValue] = cookie.split('=').map((c) => c.trim())
        if (cookieName === 'token') {
            const cookie: IToken = JSON.parse(cookieValue)
            return cookie.token
        }
    }
    return ''
}
export { setToken, removeToken, getToken }
