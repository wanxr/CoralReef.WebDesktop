const Components = require('unplugin-vue-components/webpack')
const { ElementPlusResolver } = require('unplugin-vue-components/resolvers')

module.exports = {
  // // build输出目录
  // outputDir: '../SparkNest/Assets',
  // // 静态资源目录（js, css, img）
  // assetsDir: '',
  // // publicPath: './',
  // devServer: {
  //     // 是否自动弹出浏览器页面
  //     // open: true,
  //     host: 'localhost',
  //     port: 8080,
  // },
  configureWebpack: {
    devtool: 'source-map',
    plugins: [
      Components({
        resolvers: [ElementPlusResolver()]
      })
    ]
  },
  filenameHashing: false, // 生成的静态资源在它们的文件名中包含了 hash 以便更好的控制缓存 想要去除hash 值，置为false
  lintOnSave: false, // eslint-loader 是否在保存的时候检查
  productionSourceMap: false // 生产环境是否生成 sourceMap 文件
}
