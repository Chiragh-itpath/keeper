import type { IUser } from '@/Models/UserModel';
import type { Guid } from 'guid-typescript';
import { defineStore } from 'pinia';
import { GetUser } from '@/Services/UserService';
import { ref } from 'vue';

export const UserStore = defineStore('user', () => {
    const User = ref<IUser>();
    async function StoreUser(id: Guid): Promise<void> {
        User.value = await GetUser(id)
    }
    return {
        StoreUser,
        User
    }
})