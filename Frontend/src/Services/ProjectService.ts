import type { IProject } from "@/Models/ProjectModel";
import type {IProjectUpdate} from "@/Models/ProjectUpdateModel";
import {http} from "@/GlobalConfig/ApiClient";
import axios from "axios";

const token="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJKV1RTZXJ2aWNlQWNjZXNzVG9rZW4iLCJqdGkiOiI1MzM5ZDkzZC1mYTQ0LTQ5NWYtOGY1ZS1lODg1MmJmMzI1YzAiLCJpYXQiOiIxNC0wNi0yMDIzIDA4OjMzOjI3IEFNIiwiSWQiOiIwMTQxNDE1NS03ZTQ1LTQwMmMtOWUwYy0wYTRlYWZiZmFhZTgiLCJleHAiOjE2ODY3MzUxNDcsImlzcyI6IkpXVEF1dGhlbnRpY2F0aW9uU2VydmVyIiwiYXVkIjoiSldUU2VydmljZVBvc3RtYW5DbGllbnQifQ.OQ-ZrOofVjv-rG27P99cVyX1glkMLaZonH0KUD3lLMY"
const config={headers:{Authorization: `Bearer ${token}`}}

export async function Insert(Project:IProject): Promise<any> {
    try {
        const response = await http.post('/Project',Project,config)
        console.log(response);
        return response;
    }
    catch (e) {
        console.log(e);
        return e;
    }
}
export async function GetById(ProjectId:string):Promise<any>{
    try{
        const response=await http.get(`/Project/${ProjectId}`,config)
        console.log(response);
        return response;
    }
    catch (e) {
        console.log(e);
        return e;
    }
}
export async function GetAll(UserId:string):Promise<any>{
    try{
        const response=await http.get(`/Project/${UserId}`,config)
        console.log(response);
        return response;
    }
    catch (e) {
        console.log(e);
        return e;
    }
}
export async function Delete(ProjectId:string):Promise<any>{
    try{
        const response=await http.delete(`/Project/${ProjectId}`,config)
        console.log(response);
        return response;
    }
    catch (e) {
        console.log(e);
        return e;
    }
}
export async function Update(Project:IProjectUpdate):Promise<any>{
    try{
        const response=await http.put('/Project',Project,config)
        console.log(response);
        return response;
    }
    catch (e) {
        console.log(e);
        return e;
    }
}
