import 'vuetify/styles'
import '@mdi/font/css/materialdesignicons.css'
import '@vueup/vue-quill/dist/vue-quill.snow.css'
import { createApp } from 'vue'
import { router } from '@/router'
import { vuetify } from '@/config/vuetifyConfig'
import { pinia } from '@/config/piniaConfig'
import App from './App.vue'

const app = createApp(App)

app.use(vuetify).use(router).use(pinia)

app.mount('#app')
