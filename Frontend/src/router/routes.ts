import { RouterEnum } from "@/enum/RouterEnum";
import home from "@/pages/home.vue";
import login from '@/pages/SignInPage.vue';
import signUp from "@/pages/signUp.vue";
import ForgotPassword from "@/pages/ForgotPasswordPage.vue";
export const routes = [
    {
        path: '/', 
        component: home,
        name:RouterEnum.Home
    },
    {
        path:'/signin',
        component:login,
        name:RouterEnum.SignIn
    },
    {
        path:'/signup',
        component:signUp,
        name:RouterEnum.SignUp
    },
    {
        path:'/forgotPassword',
        component:ForgotPassword,
        name:RouterEnum.ForgotPassword
    },
]

