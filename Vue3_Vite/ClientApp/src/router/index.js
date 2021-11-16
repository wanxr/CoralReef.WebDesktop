import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import X6Demo from '../views/X6Demo.vue'

const routes = [
  {
    path: '/',
    name: 'X6',
    component: X6Demo
  }
]

const router = createRouter({
  // history: createWebHistory(process.env.BASE_URL),
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
})

export default router
