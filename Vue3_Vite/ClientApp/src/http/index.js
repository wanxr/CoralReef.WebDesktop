import axios from 'axios'
import router from '@/router'

axios.interceptors.request.use(
  (config) => {
    if (localStorage.getItem('Authorization')) {
      config.headers.Authorization = localStorage.getItem('Authorization')
    }
    return config
  },
  (error) => {
    window.message.error(error.message)
  }
)

axios.interceptors.response.use(
  (success) => {
    if (success.status && success.status === 200 && success.data.code !== 1000) {
      window.message.error(success.data.msg)
      return
    }
    if (success.data.msg) {
      window.message.success(success.data.msg)
    }
    return success.data
  },
  (error) => {
    if (error.response.status === 504 || error.response.status === 404) {
      window.message.error('服务器被吃了')
    } else if (error.response.status === 403) {
      window.message.error('权限不足，请联系管理员')
    } else if (error.response.status === 401) {
      window.message.error(error.response.data.msg ? error.response.data.msg : '尚未登录，请登录')

      localStorage.removeItem('Authorization')
      router.replace('/')
    } else {
      if (error.response.data.msg) {
        window.message.error(error.response.data.msg)
      } else {
        window.message.error('未知错误!')
      }
    }
  }
)

// const base = 'http://api.app.local'
const base = ''

export const postKeyValueRequest = (url, params) => {
  return axios({
    method: 'post',
    url: `${base}${url}`,
    data: params,
    transformRequest: [
      function (data) {
        let ret = ''
        for (const i in data) {
          ret += encodeURIComponent(i) + '=' + encodeURIComponent(data[i]) + '&'
        }
        return ret
      }
    ],
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded'
    }
  })
}

export const postRequest = (url, params) => {
  return axios({
    method: 'post',
    url: `${base}${url}`,
    data: params
  })
}

export const putRequest = (url, params) => {
  return axios({
    method: 'put',
    url: `${base}${url}`,
    data: params
  })
}

export const getRequest = (url, params) => {
  return axios({
    method: 'get',
    url: `${base}${url}`,
    params: params
  })
}

export const deleteRequest = (url, params) => {
  return axios({
    method: 'delete',
    url: `${base}${url}`,
    params: params
  })
}
