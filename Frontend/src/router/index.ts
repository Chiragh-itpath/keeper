import { createRouter, createWebHistory } from 'vue-router'
import type {
    RouteRecordRaw,
    RouteLocationNormalized,
    NavigationGuardNext,
    Router
} from 'vue-router'
import { RouterEnum } from '@/Models/enum'
import SideBar from '@/components/SideBar.vue'
import NavBar from '@/components/NavBar.vue'
import VerifyEmail from '@/components/VerifyEmail.vue'
import VerifyOtp from '@/components/VerifyOtp.vue'
import ResetPassword from '@/components/ResetPassword.vue'
import AllProjects from '@/components/Project/AllProjects.vue'
import SharedProjects from '@/components/Project/SharedProjects.vue'
import TagProjects from '@/components/Project/TagProjects.vue'
import AllKeeps from '@/components/keeps/AllKeeps.vue'
import TagKeep from '@/components/keeps/TagKeep.vue'
import { getToken } from '@/Services/TokenService'
import { beforeResolve } from '@/router/RouterHelper'

import {
    ForgotPasswordPage,
    HomePage,
    ItemPage,
    KeepPage,
    LoginPage,
    PageNotFound,
    ProjectPage,
    SignUpPage
} from '@/pages'

const IsLoggedIn = (): boolean => {
    const token = getToken()
    return token != ''
}

const requireLoggedIn = (
    to: RouteLocationNormalized,
    from: RouteLocationNormalized,
    next: NavigationGuardNext
) => {
    if (IsLoggedIn()) {
        next()
    } else {
        next({ name: RouterEnum.LOGIN })
    }
}
const routes: RouteRecordRaw[] = [
    {
        path: '/',
        component: HomePage,
        name: RouterEnum.HOME
    },
    {
        path: '/login',
        component: LoginPage,
        name: RouterEnum.LOGIN
    },
    {
        path: '/signup',
        component: SignUpPage,
        name: RouterEnum.SIGNUP
    },
    {
        path: '/User',
        component: ForgotPasswordPage,
        children: [
            {
                path: 'VerifyEmail',
                component: VerifyEmail,
                name: RouterEnum.VERIFY_EMAIL
            },
            {
                path: 'VerifyOtp',
                component: VerifyOtp,
                name: RouterEnum.VERIFY_OTP,
                meta: { email: '' }
            },
            {
                path: 'ResetPassword',
                component: ResetPassword,
                name: RouterEnum.PASSWORD_RESET
            }
        ]
    },
    {
        path: '/:pathMatch(.*)*',
        components: { default: PageNotFound },
        name: RouterEnum.PAGE_NOT_FOUND
    },
    {
        path: '/Projects/',
        children: [
            {
                path: '',
                component: AllProjects,
                name: RouterEnum.PROJECT
            },
            {
                path: 'Shared',
                component: SharedProjects,
                name: RouterEnum.SHARED
            },
            {
                path: 'Tag/:tag',
                component: TagProjects,
                name: RouterEnum.PROJECT_BY_TAG
            }
        ],
        components: {
            default: ProjectPage,
            NavBar: NavBar,
            SideBar: SideBar
        },
        beforeEnter: requireLoggedIn
    },
    {
        path: '/Keeps/:id',
        children: [
            {
                path: '',
                component: AllKeeps,
                name: RouterEnum.KEEP
            },
            {
                path: 'Tag/:tag',
                component: TagKeep,
                name: RouterEnum.KEEP_BY_TAG
            }
        ],
        components: {
            default: KeepPage,
            NavBar: NavBar,
            SideBar: SideBar
        },
        beforeEnter: requireLoggedIn
    },
    {
        path: '/Items/:id',
        components: {
            default: ItemPage,
            NavBar: NavBar,
            SideBar: SideBar
        },
        name: RouterEnum.ITEM,
        beforeEnter: requireLoggedIn
    }
]
const router: Router = createRouter({
    history: createWebHistory(),
    routes: routes
})
router.beforeResolve(async (to) => {
    await beforeResolve(to)
})
export { router }
