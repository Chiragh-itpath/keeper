import type { IUser } from '@/Models/UserModel'
import { http } from '@/GlobalConfig/ApiClient'
const GetUser = async (id: string): Promise<IUser> => {
  const response = await http.get(`User/${id}`, {
    headers: {
      'Content-Type': 'application/json'
    }
  })
  return response.data.data
}
async function GetByEmail(email:string):Promise<any>{
  const response=await http.get(`User/Email/${email}`)
  return response.data.data
}
async function GetById(id:string):Promise<any>{
  const response=await http.get(`User/${id}`)
  return response.data.data
}
export { GetUser,GetByEmail,GetById }
