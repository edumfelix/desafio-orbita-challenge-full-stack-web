/**
 * main.ts
 *
 * Bootstraps Vuetify and other plugins then mounts the App`
 */

// Plugins
import { registerPlugins } from '@/plugins'

// Components
import App from './App.vue'

// Composables
import { createApp } from 'vue'

import axios from 'axios'


axios.defaults.baseURL = "https://localhost:7198/api/v1/student"


const app = createApp(App)

registerPlugins(app)

app.mount('#app')
