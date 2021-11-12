import router from '@/router/index'
import { message } from '@/utils/message'
import { postKeyValueRequest, postRequest, putRequest, deleteRequest, getRequest } from '@/http/index'
import './external.js'

window.message = {}

window.message.info = (msg) => {
  message.info({
    message: msg
  })
}

window.message.error = (msg) => {
  message.error({
    message: msg
  })
}

window.message.warning = (msg) => {
  message.warning({
    message: msg
  })
}

window.message.success = (msg) => {
  message.success({
    message: msg
  })
}

window.sleep = (numberMillis) => {
  var now = new Date()
  var exitTime = now.getTime() + numberMillis
  while (true) {
    now = new Date()
    if (now.getTime() > exitTime) return
  }
}

window.postRequest = postRequest
window.postKeyValueRequest = postKeyValueRequest
window.putRequest = putRequest
window.deleteRequest = deleteRequest
window.getRequest = getRequest
