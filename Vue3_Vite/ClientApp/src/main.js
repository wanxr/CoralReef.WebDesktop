import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import 'element-plus/dist/index.css'

import elementPlus from './plugins/element'
import './assets/css/normalize.css'
import './assets/css/app.css'
import './api/window_global.js'

const app = createApp(App)
app.use(store).use(elementPlus).use(router)
app.config.errorHandler = (err, vm, info) => {
  window.message.error(err)
}
app.mount('#app')
