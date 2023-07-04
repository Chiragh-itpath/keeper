import type { IMail } from '@/Models/MailModel'
import { SendMail } from '@/Services/MailService'
import { defineStore } from 'pinia'
import { useUserStore } from '@/stores/UserStore'
export const useMailStore = defineStore('MailStore', () => {
  async function Mail(Mail: IMail): Promise<any> {
    Mail.UserId = useUserStore().User?.id
    await SendMail(Mail)
  }
  return {
    Mail
  }
})
