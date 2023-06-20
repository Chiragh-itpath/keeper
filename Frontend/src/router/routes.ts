import { RouterEnum } from "@/enum/RouterEnum";
import { useUserStore } from '@/stores/UserStore';
import { type RouteLocationNormalized, type NavigationGuardNext } from 'vue-router';
import home from "@/pages/HomePage.vue";
import login from '@/pages/LoginPage.vue';
import signUp from "@/pages/SignUpPage.vue";
import ForgotPassword from "@/pages/ForgotPasswordPage.vue";
import ProjectPage from '@/pages/ProjectPage.vue';
import KeepPage from "@/pages/KeepPage.vue";
import ItemPage from "@/pages/ItemPage.vue";
import  EditProject  from "@/pages/EditProject.vue";
export const routes = [
    {
        path: '/',
        component: home,
        name: RouterEnum.HOME
    },
    {
        path: '/login',
        component: login,
        name: RouterEnum.LOGIN
    },
    {
        path: '/signup',
        component: signUp,
        name: RouterEnum.SIGNUP
    },
    {
        path: '/forgotPassword',
        component: ForgotPassword,
        name: RouterEnum.FORGOT_PASSWORD
    },
    {
        path: '/Projects',
        component: ProjectPage,
        name: RouterEnum.PROJECT,
        beforeEnter: routeGuard,
    },
    {
        path: '/Keeps',
        component: KeepPage,
        name: RouterEnum.KEEP,
        beforeEnter: routeGuard,
    },
    {
        path: '/Items',
        component: ItemPage,
        name: RouterEnum.ITEM,
        beforeEnter: routeGuard,
    },
    {
        path:'/EditProject',
        component:EditProject,
        name:RouterEnum.EDITPROJECT,
        beforeEnter:routeGuard
    }
]

function routeGuard(to: RouteLocationNormalized, from: RouteLocationNormalized, next: NavigationGuardNext) {
    const { isLoggedin } = useUserStore()
    if (isLoggedin) next()
    else next({ name: RouterEnum.LOGIN })
}