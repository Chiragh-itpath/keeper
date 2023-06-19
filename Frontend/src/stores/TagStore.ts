import { defineStore } from "pinia";
import { Get,GetByTitle,GetByType,Post } from "@/Services/TagService";
import type { TagTypeEnum } from "@/enum/TagTypeEnum";
import type { ITag } from "@/Models/TagModel";
export const useTagStore=defineStore("TagStore",()=>{  
    let TagList:ITag[]|undefined;

    async function GetAllTags():Promise<ITag[] | undefined>{
        try{
            const response = await Get();
            console.log(response);
             TagList = response.data;
            return TagList;
        }
        catch(error){
            console.log(error);
        }
    }
     async function GetByTagType(tagType:TagTypeEnum):Promise<any>{
        try {
            return await GetByType(tagType);
        } catch (error) {
            console.log(error);
        }
    }
    
     async function GetByTagTitle(title:string):Promise<any>{
        try {
            return await GetByTitle(title);
        } catch (error) {
            console.log(error);
        }
    }
    
     async function Add(tag:ITag):Promise<void>{
        try {
            await Post(tag);
            TagList = await GetAllTags();
            
        } catch (error) {
            console.log(error);
        }
    }
    return{
        GetAllTags,GetByTagTitle,GetByTagType,Add
    }
})

