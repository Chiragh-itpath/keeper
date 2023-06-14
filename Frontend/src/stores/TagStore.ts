import { defineStore } from "pinia";
import { Get,GetByTitle,GetByType,Post } from "@/Services/TagService";
import type { TagTypeEnum } from "@/enum/TagTypeEnum";
import axios from "axios";
import type { ITag } from "@/Models/TagModel";
export const tagStore=defineStore("TagStore",()=>{
    async function Get():Promise<any>{
        try{
            return await Get();
        }
        catch(error){
            console.log(error);
        }
    }
     async function GetByType(tagType:TagTypeEnum):Promise<any>{
        try {
            return await GetByType(tagType);
        } catch (error) {
            console.log(error);
        }
    }
    
     async function GetByTitle(title:string):Promise<any>{
        try {
            return await GetByTitle(title);
        } catch (error) {
            console.log(error);
        }
    }
    
     async function Post(tag:ITag):Promise<any>{
        try {
            return await Post(tag);
        } catch (error) {
            console.log(error);
        }
    }
    return{
        Get,GetByTitle,GetByType,Post
    }
})

