import { ElMessage, ElNotification } from 'element-plus'

const showMessage = Symbol('showMessage')

class Message {
  [showMessage](type, options, single) {
    if (!options) {
      options = { message: '' }
    }
    options.showClose = true
    options.position = 'bottom-right'
    options.duration = 3000
    if (single) {
      if (document.getElementsByClassName('el-message').length === 0) {
        // ElMessage[type](options)
        ElNotification[type](options)
      }
    } else {
      // ElMessage[type](options)
      ElNotification[type](options)
    }
  }

  info(options, single = true) {
    this[showMessage]('info', options, single)
  }

  warning(options, single = true) {
    this[showMessage]('warning', options, single)
  }

  error(options, single = true) {
    this[showMessage]('error', options, single)
  }

  success(options, single = true) {
    this[showMessage]('success', options, single)
  }
}

export const message = new Message()
