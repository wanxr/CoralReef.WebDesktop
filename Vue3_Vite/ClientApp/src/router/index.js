import { createRouter, createWebHistory } from 'vue-router'
import Login from '../views/login/Login.vue'
import Test from '../views/Test.vue'

const routes = [
  {
    path: '/',
    name: 'Login',
    component: Login
  },
  {
    path: '/Home',
    name: 'Home',
    component: Test
  }
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
})

export default router
