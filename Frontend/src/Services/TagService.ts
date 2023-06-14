import type { ITag } from "@/Models/TagModel";
import axios from "axios";
import type { TagTypeEnum } from "@/enum/TagTypeEnum";
const token="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJKV1RTZXJ2aWNlQWNjZXNzVG9rZW4iLCJqdGkiOiI3MGNmOTNiZS1lNDQ1LTQxZWQtYTc5OS1iOTVkMjE4YTJmNWUiLCJpYXQiOiIwNi8xNC8yMyAxMTo0MDoxOSBBTSIsIklkIjoiNTMzZTQyMzktZDQ1Yy00NDlmLThlODEtZTI4OWM4M2UxNmU0IiwiZXhwIjoxNjg2NzQ2MzU5LCJpc3MiOiJKV1RBdXRoZW50aWNhdGlvblNlcnZlciIsImF1ZCI6IkpXVFNlcnZpY2VQb3N0bWFuQ2xpZW50In0.XrxbiCsy8G09WJ7OLhCaiqLuh-DOCLuByAHDGemUmYM"
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