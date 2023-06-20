import type { IUser } from '@/Models/UserModel';
import { Guid } from 'guid-typescript';
import { defineStore } from 'pinia';
import { GetUser } from '@/Services/UserService';
import { computed, ref } from 'vue';
import { useTokenStore } from '@/stores/TokenStore';
import { useCookies } from 'vue3-cookies';
import { useRouter } from 'vue-router';
const router=useRouter()
const {cookies}=useCookies()
export const useUserStore = defineStore('user', () => {
    let User = ref<IUser>();
    const { getToken } = useTokenStore();
    async function StoreUser(id: Guid): Promise<void> {
        User.value = await GetUser(id)
    }
    const isLoggedin = computed(
        () => User.value != undefined && getToken() != ""
    );
    function logout(){
        User.value=undefined;
        cookies.remove("token")
        router.push("/")
    }
    return {
        StoreUser,
        User,
        isLoggedin,
        logout
    }
}, {
    persist: true
})