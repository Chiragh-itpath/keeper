import type { IMail } from "@/Models/MailModel";
import { SendMail } from "@/Services/MailService";
import { defineStore } from "pinia";

export const useMailStore=defineStore('MailStore',()=>{
    async function Mail(Mail:IMail):Promise<any>{
        await SendMail(Mail)
    }
return{
    Mail
}
})