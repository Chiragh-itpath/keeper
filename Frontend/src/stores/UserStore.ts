import type { IUser } from '@/Models/UserModel';
import { Guid } from 'guid-typescript';
import { defineStore } from 'pinia';
import { GetUser } from '@/Services/UserService';
import { computed, ref } from 'vue';
import { useCookies } from 'vue3-cookies';
const { cookies } = useCookies();


export const useUserStore = defineStore('user', () => {
    const User = ref<IUser>();
    async function StoreUser(id: Guid): Promise<void> {
        User.value = await GetUser(id)
    }
    const isLoggedin = computed(() => { return User.value != undefined || cookies.get('token') != undefined });
    
    return {
        StoreUser,
        User,
        isLoggedin
    }
},{
    persist: true
})