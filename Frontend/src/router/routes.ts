import { RouterEnum } from "@/enum/RouterEnum";
import home from "@/pages/HomePage.vue";
import login from '@/pages/LoginPage.vue';
import signUp from "@/pages/SignUpPage.vue";
import ForgotPassword from "@/pages/ForgotPasswordPage.vue";
export const routes = [
    {
        path: '/', 
        component: home,
        name:RouterEnum.HOME
    },
    {
        path:'/login',
        component:login,
        name:RouterEnum.LOGIN
    },
    {
        path:'/signup',
        component:signUp,
        name:RouterEnum.SIGNUP
    },
    {
        path:'/forgotPassword',
        component:ForgotPassword,
        name:RouterEnum.FORGOT_PASSWORD
    },
]

