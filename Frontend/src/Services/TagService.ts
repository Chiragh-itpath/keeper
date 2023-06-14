import type { ITag } from "@/Models/TagModel";
import axios from "axios";
import type { TagTypeEnum } from "@/enum/TagTypeEnum";
const token="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJKV1RTZXJ2aWNlQWNjZXNzVG9rZW4iLCJqdGkiOiI1YzQwYTE4Yy1iZjc5LTQyNTEtYjdiOC0yZWQ1YWIyNWZmMzYiLCJpYXQiOiIwNi8xNC8yMyA5OjIyOjQ5IEFNIiwiSWQiOiI1MzNlNDIzOS1kNDVjLTQ0OWYtOGU4MS1lMjg5YzgzZTE2ZTQiLCJleHAiOjE2ODY3MzgxMDksImlzcyI6IkpXVEF1dGhlbnRpY2F0aW9uU2VydmVyIiwiYXVkIjoiSldUU2VydmljZVBvc3RtYW5DbGllbnQifQ.ZczwMwIezVa1YpoLJGWFB72Vt5q4OHcSSpJodeSEjSs"
const headers = { 
    "Authorization": `Bearer ${token}`,
  };
export async function Get():Promise<any>{
    try {
        return await axios.get("https://localhost:7134/api/Tag",{headers:headers});
    } catch (error) {
        console.log(error);
    }
}
export async function GetByType(tagType:TagTypeEnum):Promise<any>{
    try {
        return await axios.get(`https://localhost:7134/api/Tag/Type/${tagType}`,{headers:headers});
    } catch (error) {
        console.log(error);
    }
}

export async function GetByTitle(title:string):Promise<any>{
    try {
        return await axios.get(`https://localhost:7134/api/Tag/Title/${title}`,{headers:headers});
    } catch (error) {
        console.log(error);
    }
}

export async function Post(tag:ITag):Promise<any>{
    try {
        return await axios.post(`https://localhost:7134/api/Tag`,tag,{headers:headers});
    } catch (error) {
        console.log(error);
    }
}