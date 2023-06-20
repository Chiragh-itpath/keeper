import type { IUser } from "@/Models/UserModel";
import axios from "axios";
import type { Guid } from "guid-typescript";
const GetUser = async(id: Guid) : Promise<IUser> => {
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