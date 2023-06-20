import type { IUser } from '@/Models/UserModel';
<<<<<<< HEAD
import { defineStore, } from 'pinia';
=======
import { Guid } from 'guid-typescript';
import { defineStore } from 'pinia';
>>>>>>> b81059fdc8a5e13bca3ab9b09963365c3df96085
import { GetUser } from '@/Services/UserService';
import { computed, ref } from 'vue';
import { useTokenStore } from '@/stores/TokenStore';
import { useCookies } from 'vue3-cookies';
import { useRouter } from 'vue-router';
const {cookies}=useCookies()
export const useUserStore = defineStore('user', () => {
    const router=useRouter()
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