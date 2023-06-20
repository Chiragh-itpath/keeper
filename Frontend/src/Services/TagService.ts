import type { ITag } from "@/Models/TagModel";
import type { TagTypeEnum } from "@/enum/TagTypeEnum";
import { http } from "@/GlobalConfig/ApiClient";
export async function Get():Promise<any>{
    try {
        const response = await http.get("Tag");
        return await response.data;
    } catch (error) {
        console.log(error);
    }
}
export async function GetByType(tagType:TagTypeEnum):Promise<any>{
    try {
        const response = await http.get(`Tag/Type/${tagType}`);
        return await response.data;
    } catch (error) {
        console.log(error);
    }
}

export async function GetByTitle(title:string):Promise<any>{
    try {
        const response = await http.get(`Tag/Title/${title}`);
        return await response.data;
    } catch (error) {
        console.log(error);
    }
}

export async function Post(tag:ITag):Promise<any>{
    try {
        const response = await http.post(`Tag`,tag);
        return await response.data;
    } catch (error) {
        console.log(error);
    }
}