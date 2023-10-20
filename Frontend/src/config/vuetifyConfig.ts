import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

const siteTheme = {
    dark: false,
    colors: {
        success: '#198754',
        info: '#0dcaf0',
        warning: '#ffc107',
        danger: '#dc3545',
        primary: '#26A69A',
        'blur-white': '#f7f9fc'
    }
}

const vuetify = createVuetify({
    components,
    directives,
    theme: {
        defaultTheme: 'siteTheme',
        themes: {
            siteTheme
        }
    }
})
export { vuetify }
