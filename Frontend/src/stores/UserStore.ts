import type { IUser } from '@/Models/UserModel';
import { Guid } from 'guid-typescript';
import { defineStore } from 'pinia';
import { GetUser } from '@/Services/UserService';
import { computed, ref } from 'vue';
import { useTokenStore } from '@/stores/TokenStore';

export const useUserStore = defineStore('user', () => {
    const User = ref<IUser>();
    const { getToken } = useTokenStore();
    async function StoreUser(id: Guid): Promise<void> {
        User.value = await GetUser(id)
    }
    const isLoggedin = computed(
        () => User.value != undefined && getToken() != ""
    );

    return {
        StoreUser,
        User,
        isLoggedin
    }
}, {
    persist: true
})