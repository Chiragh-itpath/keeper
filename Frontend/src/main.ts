import 'vuetify/styles'
import { createApp } from 'vue'
import { createVuetify } from 'vuetify';
import { createRouter, createWebHistory } from 'vue-router';
import { createPinia } from 'pinia';
import App from './App.vue'
import * as components from 'vuetify/components';
import * as directives from 'vuetify/directives';
import "@mdi/font/css/materialdesignicons.css";
import {routes} from "@/router/routes";

const app = createApp(App)
const vuetify = createVuetify({
    components,
    directives
})

const router = createRouter({
    history: createWebHistory(),
    routes: routes
});

const pinia = createPinia()

app.use(vuetify)
app.use(router)
app.use(pinia)
app.mount('#app')
