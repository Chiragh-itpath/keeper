import { RouterEnum } from "@/enum/RouterEnum";
import home from "@/pages/HomePage.vue";
import login from '@/pages/SignInPage.vue';
import signUp from "@/pages/SignUpPage.vue";
import ForgotPassword from "@/pages/ForgotPasswordPage.vue";
export const routes = [
    {
        path: '/', 
        component: home,
        name:RouterEnum.HOME
    },
    {
        path:'/signin',
        component:login,
        name:RouterEnum.SIGNIN
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

