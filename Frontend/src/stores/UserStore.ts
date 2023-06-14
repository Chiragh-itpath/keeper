import type { IUser } from '@/Models/UserModel';
import { Guid } from 'guid-typescript';
import { defineStore } from 'pinia';
import { GetUser } from '@/Services/UserService';
import { computed, ref } from 'vue';
import { useCookies } from 'vue3-cookies';
const { cookies } = useCookies();


export const UserStore = defineStore('user', () => {
    const User = ref<IUser>();
    async function StoreUser(id: Guid): Promise<void> {
        User.value = await GetUser(id)
    }
    const isLoggedin = computed(() => { return cookies.get('token') != null });
    
    return {
        StoreUser,
        User,
        isLoggedin
    }
})