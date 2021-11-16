// import ElementPlus from 'element-plus'
import '../element-variables.scss'
import locale from 'element-plus/lib/locale/lang/zh-cn'

export default (app) => {
  // app.use(ElementPlus, { locale, size: 'mini', zIndex: 3000 })
  app.config.globalProperties.$ELEMENT = {
    locale,
    size: 'mini',
    zIndex: 3000
  }
}
