import type { Ikeep } from "@/Models/KeepModel";
import { defineStore } from "pinia";
import{Insert,Update,Delete,GetAll,GetById} from "@/Services/KeepService"
export const useKeepStore=defineStore('KeepStore',()=>{
    
    async function AddKeep(keep:Ikeep):Promise<any>{
        return await Insert(keep)
    }
    async function GetKeepById(KeepId:string):Promise<any>{
        return await GetById(KeepId)
    }
    async function GetKeeps(ProjectId:string):Promise<any> {
        return await GetAll(ProjectId)
    }
    async function DeleteKeep(ProjectId:string):Promise<any>{
        return await Delete(ProjectId)
    }
    async function Updatekeep(Keep:Ikeep):Promise<any>{
        return await Update(Keep)
    }
    return{
        AddKeep,
        GetKeepById,
        GetKeeps,
        DeleteKeep,
        Updatekeep
    }
})