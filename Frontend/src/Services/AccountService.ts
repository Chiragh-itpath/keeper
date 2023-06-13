import type { ILogin } from "@/Models/LoginModel";
import type { IRegister } from "@/Models/RegisterModel";
import axios from "axios";

async function signup(user: IRegister): Promise<string> {
    const resp = await axios.post(
        'https://localhost:7134/api/Account/Register',     
            user      
    )
    console.log(resp);   
    return ""
}

async function signin(user:ILogin):Promise<string>{
    console.log(user);   
    const res=await axios.post(
       'https://localhost:7134/api/Account/Login' ,
       user
    )
    console.log(res)
    return "Logged in"
}
export {
    signup,
    signin
}