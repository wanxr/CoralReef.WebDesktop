import { createRouter, createWebHistory } from 'vue-router'
import Test from '../views/Test.vue'

const routes = [
  {
    path: '/',
    name: 'Test',
    component: Test
  }
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
})

export default router
