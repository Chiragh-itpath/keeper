import type { Ikeep } from "@/Models/KeepModel";
import { type Ref,ref } from "vue";
import { defineStore,storeToRefs } from "pinia";
import{Insert,Update,Delete,GetAll,GetById} from "@/Services/KeepService"
import { useUserStore } from "./UserStore";
export const useKeepStore=defineStore('KeepStore',()=>{
    const { User } = storeToRefs(useUserStore());
    const Keeps: Ref<Ikeep[]> = ref([])
    async function AddKeep(keep:Ikeep):Promise<any>{
        keep.createdBy=User.value?.id
        await Insert(keep)
        return await GetKeeps()
    }
    async function GetKeepById(KeepId:string):Promise<any>{
        return await GetById(KeepId)
    }
    async function GetKeeps():Promise<any> {
         const keeps= await GetAll("55763296-d8ee-45eb-acae-319481fdf02e")
         Keeps.value=keeps.data.data
    }
    async function DeleteKeep(ProjectId:string):Promise<any>{
        await Delete(ProjectId)
        await GetKeeps()
    }
    async function Updatekeep(Keep:Ikeep):Promise<any>{
        Keep.updatedBy=User.value?.id
         await Update(Keep)
         await GetKeeps()
    }
    return{
        AddKeep,
        GetKeepById,
        GetKeeps,
        DeleteKeep,
        Updatekeep,
        Keeps
    }
})