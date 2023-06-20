import { http } from "@/GlobalConfig/ApiClient";
import type { Ikeep } from "@/Models/KeepModel";

export async function Insert(Keep:Ikeep):Promise<any>{
    try{
        console.log(Keep);
        const response= await http.post('/keep',Keep)
       console.log(response);
       return response;
    }
    catch(e){
        console.log(e);
        return e;
    }
}
export async function Update(keep:Ikeep):Promise<any>{
    try{
        const response=await http.put('/Keep',keep)
        console.log(response);
        return response;
    }
    catch(e){
        console.log(e);
        return e;
    }
}
export async function Delete(KeepId:string):Promise<any>{
    try{
        const response=await http.delete(`/Keep/${KeepId}`)
        console.log(response);
        return response;
    }
    catch(e){
        console.log(e);
        return e;
    }
}
export async function GetAll(ProjectId:string):Promise<any>{
    try{
        const response=await http.get(`/Keep?ProjectId=${ProjectId}`)
        console.log(response);
        return response;
    }
    catch(e){
        console.log(e);
        return e;
    }
}
export async function GetById(KeepId:string):Promise<any> {
    try{
        const response=await http.get(`/Keep/${KeepId}`)
        console.log(response);
        return response;
    }
    catch(e){
        console.log(e);
        return e;
    }
    
}