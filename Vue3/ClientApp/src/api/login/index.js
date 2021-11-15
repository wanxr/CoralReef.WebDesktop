import { postRequest } from '@/http/index'

export const login = (loginInfo) => {
  return postRequest('/user/login', loginInfo)
}

export const updateCode = () => {
  return postRequest('')
}
