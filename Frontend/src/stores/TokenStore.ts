import { defineStore } from 'pinia'
import { useCookies } from 'vue3-cookies'
const { cookies } = useCookies()

export const useTokenStore = defineStore('token', () => {
  function setToken(token: string): void {
    cookies.set('token', JSON.stringify(token), 60 * 60)
  }
  const getToken = (): string => {
    let token = cookies.get('token')
    if (token == null) return ''
    return token.replace(/"/g, '')
  }

  return {
    setToken,
    getToken
  }
})
