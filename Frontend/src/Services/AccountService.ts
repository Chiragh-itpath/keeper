import type { IRegister } from "@/Models/RegisterModel";
import axios from "axios";

async function signup(user: IRegister): Promise<string> {
    console.log(user);   
    const resp = await axios.post(
        'https://localhost:7134/api/Account/Register',     
            user      
    )
    console.log(resp);   
    return ""
}
export {
    signup
}