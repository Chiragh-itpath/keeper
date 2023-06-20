import type { IUser } from "@/Models/UserModel";
import axios from "axios";
const GetUser = async(id: string) : Promise<IUser> => {
    const response = await axios.get(
        `https://localhost:7134/api/User/${id}`,
        {
            headers:{
                'Content-Type': 'application/json'
            }
        }
    )
    return response.data.data
    
}
export {
    GetUser
}