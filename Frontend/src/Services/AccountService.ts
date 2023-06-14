import type { ILogin } from "@/Models/LoginModel";
import type { IRegister } from "@/Models/RegisterModel";
import axios from "axios";

async function signup(user: IRegister): Promise<any> { 
    try {
        const response = await axios.post(
            'https://localhost:7134/api/Account/Register',
            user
        )
        return response;
    }
    catch (e) {
        return e;
    }
}

async function signin(user: ILogin): Promise<any> {
    console.log(user);   
    try {
        const response = await axios.post(
            'https://localhost:7134/api/Account/Login',
            user
        )
        return response;
    }
    catch (e) {
        return e;
    }
}
export {
    signup,
    signin
}