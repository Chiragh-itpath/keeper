import type { IMail } from "@/Models/MailModel";
import { http } from "@/GlobalConfig/ApiClient";

export async function SendMail(Mails:IMail) {
    try{
        const response=await http.post('/Mail',Mails)
        return response;
    }catch(e){
        console.log(e)
        return e
    }
}