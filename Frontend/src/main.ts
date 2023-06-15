import 'vuetify/styles'
import { createApp } from 'vue'
import { createVuetify } from 'vuetify';
import * as components from 'vuetify/components';
import * as directives from 'vuetify/directives';
import "@mdi/font/css/materialdesignicons.css";
import { createRouter, createWebHistory } from 'vue-router';
import { createPinia } from 'pinia';
import { routes } from "@/router/routes";
import { siteTheme } from '@/themes/theme';
import piniaPluginPersistedState from "pinia-plugin-persistedstate"
import App from './App.vue'


const app = createApp(App)
const vuetify = createVuetify({
    components,
    directives,
    theme: {
        defaultTheme: "siteTheme",
        themes: {
            siteTheme
        }
    },
})
const router = createRouter({
    history: createWebHistory(),
    routes: routes
});
const pinia = createPinia()

pinia.use(piniaPluginPersistedState)
app.use(vuetify)
app.use(router)
app.use(pinia)
app.mount('#app')
