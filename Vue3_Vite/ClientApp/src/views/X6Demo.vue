<template>
  <div id="divMenu" class="menu_div">
    <div style="height: 20px"></div>
    <div>
      <div style="width: 40px"></div>
      <input id="btnDelEdge" type="button" value="删除" class="btn" onclick="deleteEdge(this)" />
    </div>
  </div>
  <div id="divRelated" class="related_div" style="width: 900px; height: 600px">
    <table width="100%">
      <thead>
        <tr>
          <td colspan="3">
            <table>
              <tr>
                <td width="96%">表关系</td>
                <td style="text-align: left">
                  <a id="closePage" href="#" onclick="closePage()">关闭</a>
                </td>
              </tr>
            </table>
          </td>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>
            <table class="pure-table">
              <thead>
                <tr>
                  <th>字段1</th>
                  <th>类型</th>
                  <th>名称</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>下传日期</td>
                  <td>date</td>
                </tr>
                <tr>
                  <td>开户BRANCH号</td>
                  <td>varchar(18)</td>
                </tr>
                <tr>
                  <td>开户BRANCH号</td>
                  <td>varchar(18)</td>
                </tr>
                <tr>
                  <td>开户BRANCH号</td>
                  <td>varchar(18)</td>
                </tr>
                <tr>
                  <td>开户BRANCH号</td>
                  <td>varchar(18)</td>
                </tr>
              </tbody>
            </table>
          </td>
          <td>
            <table>
              <tr>
                <td>表关系</td>
                <td>
                  <select id="ddlConnect">
                    <option id="inner join">内连接</option>
                    <option id="left join">左连接</option>
                  </select>
                </td>
              </tr>
            </table>
          </td>
          <td>
            <table class="pure-table">
              <thead>
                <tr>
                  <th>字段1</th>
                  <th>类型</th>
                  <th>名称</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>下传日期</td>
                  <td>date</td>
                </tr>
                <tr>
                  <td>开户BRANCH号</td>
                  <td>varchar(18)</td>
                </tr>
                <tr>
                  <td>开户BRANCH号</td>
                  <td>varchar(18)</td>
                </tr>
                <tr>
                  <td>开户BRANCH号</td>
                  <td>varchar(18)</td>
                </tr>
                <tr>
                  <td>开户BRANCH号</td>
                  <td>varchar(18)</td>
                </tr>
              </tbody>
            </table>
          </td>
        </tr>
      </tbody>
    </table>
  </div>

  <div id="container" style="display: block; z-index: 3"></div>
</template>

<script>
// @ is an alias to /src
import { Graph } from '@antv/x6'
import { onMounted } from 'vue'

export default {
  name: 'Home',
  components: {},
  setup(props) {
    var graph
    var container
    onMounted(() => {
      container = document.getElementById('container')
      graph = new Graph({
        minimap: {
          enabled: true,
          container: container,
          padding: 20
        },
        connecting: {
          allowBlank: false,
          snap: true, // 自动吸附
          allowNode: true, // 是否允许边链接到节点
          connector: {
            name: 'smooth' // 连接线平滑normal | smooth | rounded | jumpover
          }
        },
        selecting: {
          enabled: true,
          rubberband: true,
          showNodeSelectionBox: true,
          className: 'my-selecting'
        },
        snapline: true,
        resizing: true,
        container: container,
        width: 1920,
        height: 1080,
        grid: {
          size: 10,
          visible: true,
          type: 'doubleMesh',
          args: [
            {
              color: '#eee', // 主网格线颜色
              thickness: 1 // 主网格线宽度
            },
            {
              color: '#ddd', // 次网格线颜色
              thickness: 1, // 次网格线宽度
              factor: 4 // 主次网格线间隔
            }
          ]
        }
      })

      // #region 初始化图形
      const ports = {
        groups: {
          top: {
            position: 'top',
            attrs: {
              circle: {
                r: 4,
                magnet: true,
                stroke: '#5F95FF',
                strokeWidth: 1,
                fill: '#fff',
                style: {
                  visibility: 'hidden'
                }
              }
            }
          },
          right: {
            position: 'right',
            attrs: {
              circle: {
                r: 4,
                magnet: true,
                stroke: '#5F95FF',
                strokeWidth: 1,
                fill: '#fff',
                style: {
                  visibility: 'hidden'
                }
              }
            }
          },
          bottom: {
            position: 'bottom',
            attrs: {
              circle: {
                r: 4,
                magnet: true,
                stroke: '#5F95FF',
                strokeWidth: 1,
                fill: '#fff',
                style: {
                  visibility: 'hidden'
                }
              }
            }
          },
          left: {
            position: 'left',
            attrs: {
              circle: {
                r: 4,
                magnet: true,
                stroke: '#5F95FF',
                strokeWidth: 1,
                fill: '#fff',
                style: {
                  visibility: 'hidden'
                }
              }
            }
          }
        },
        items: [
          {
            group: 'top'
          },
          {
            group: 'right'
          },
          {
            group: 'bottom'
          },
          {
            group: 'left'
          }
        ]
      }

      graph.drawBackground({
        color: '#f5f5f5'
      })

      const source = graph.addNode({
        x: 40,
        y: 40,
        width: 300,
        height: 300,
        ports: { ...ports },
        shape: 'html',
        html() {
          const wrap = document.createElement('div')
          wrap.id = 'div1'
          wrap.className = 'model_div'
          wrap.innerHTML = `<table class="pure-table" >
                        <caption>&nbsp;&nbsp; 财管部对公时点债券报表_5天</caption>
                        <tbody>
                            <tr>
                                <td colspan="3" style="padding:0;height:20px">
                                    <div class="model_div_no">
                                        <table class="pure-table">
                                            <thead>
                                                <tr>
                                                    <th>字段1</th>
                                                    <th>类型</th>
                                                    <th>名称</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>下传日期</td>
                                                    <td>date</td>
                                                    <td onclick="getTdVal(this)">BDF10FR_CURWKDY</td>
                                                </tr>
                                                <tr>
                                                    <td>开户BRANCH号</td>
                                                    <td>varchar(18)</td>
                                                    <td onclick="getTdVal(this)">BDF09FR_OPEN_BCH</td>
                                                </tr>
                                                <tr>
                                                    <td>开户BRANCH号</td>
                                                    <td>varchar(18)</td>
                                                    <td onclick="getTdVal(this)">BDF09FR_OPEN_BCH</td>
                                                </tr>
                                                <tr>
                                                    <td>开户BRANCH号</td>
                                                    <td>varchar(18)</td>
                                                    <td onclick="getTdVal(this)">BDF09FR_OPEN_BCH</td>
                                                </tr>
                                                <tr>
                                                    <td>开户BRANCH号</td>
                                                    <td>varchar(18)</td>
                                                    <td onclick="getTdVal(this)">BDF09FR_OPEN_BCH</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>

                                </td>
                            </tr>

                        </tbody>
                    </table>`
          return wrap
        }
      })

      const target = graph.addNode({
        x: 540,
        y: 140,
        width: 300,
        height: 300,
        ports: { ...ports },
        shape: 'html',
        html() {
          const wrap = document.createElement('div')
          wrap.id = 'div2'
          wrap.className = 'model_div'
          wrap.innerHTML = `<table class="pure-table" >
                        <caption>&nbsp;&nbsp; 财管部对公时点债券报表_5天</caption>
                        <tbody>
                            <tr>
                                <td colspan="3" style="padding:0;height:20px">
                                    <div class="model_div_no">
                                        <table class="pure-table">
                                            <thead>
                                                <tr>
                                                    <th>字段1</th>
                                                    <th>类型</th>
                                                    <th>名称</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>下传日期</td>
                                                    <td>date</td>
                                                    <td onclick="getTdVal(this)">BDF10FR_CURWKDY</td>
                                                </tr>
                                                <tr>
                                                    <td>开户BRANCH号</td>
                                                    <td>varchar(18)</td>
                                                    <td onclick="getTdVal(this)">BDF09FR_OPEN_BCH</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>

                                </td>
                            </tr>

                        </tbody>
                    </table>`
          return wrap
        }
      })

      const target1 = graph.addNode({
        x: 300,
        y: 540,
        width: 300,
        height: 300,
        ports: { ...ports },
        shape: 'html',
        html() {
          const wrap = document.createElement('div')
          wrap.id = 'div3'
          wrap.className = 'model_div'
          wrap.innerHTML = `<table class="pure-table" >
                        <caption>&nbsp;&nbsp; 财管部对公时点债券报表_5天</caption>
                        <tbody>
                            <tr>
                                <td colspan="3" style="padding:0;height:20px">
                                    <div class="model_div_no">
                                        <table class="pure-table">
                                            <thead>
                                                <tr>
                                                    <th>字段1</th>
                                                    <th>类型</th>
                                                    <th>名称</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>下传日期</td>
                                                    <td>date</td>
                                                    <td onclick="getTdVal(this)">BDF10FR_CURWKDY</td>
                                                </tr>
                                                <tr>
                                                    <td>开户BRANCH号</td>
                                                    <td>varchar(18)</td>
                                                    <td onclick="getTdVal(this)">BDF09FR_OPEN_BCH</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>

                                </td>
                            </tr>

                        </tbody>
                    </table>`
          return wrap
        }
      })

      graph.on('node:mouseenter', () => {
        var ports = document.getElementById('container').querySelectorAll('.x6-port-body')
        for (let i = 0, len = ports.length; i < len; i = i + 1) {
          ports[i].style.visibility = 'visible'
        }
      })

      graph.on('node:mouseleave', () => {
        var ports = document.getElementById('container').querySelectorAll('.x6-port-body')
        for (let i = 0, len = ports.length; i < len; i = i + 1) {
          ports[i].style.visibility = 'hidden'
        }
      })

      graph.on('edge:connected', ({ isNew, edge }) => {
        if (isNew) {
          const source = edge.getSourceCell()

          edge.appendLabel({
            attrs: { label: { text: '1:1' } }
          })

          const divRelated = document.getElementById('divRelated')
          const container = document.getElementById('container')

          var x1 = container.style.width.replace('px', '') / 2 - 450
          var y1 = container.style.height.replace('px', '') / 2 - 300

          divRelated.style.left = x1 + 'px'
          divRelated.style.top = y1 + 'px'
          divRelated.style.position = 'absolute'
          divRelated.style.zIndex = 7
          divRelated.style.display = 'block'

          edge.attr('line/targetMarker/strokeWidth', '0')
        }
      })

      graph.on('edge:dblclick', ({ e, x, y, edge, view }) => {
        const source = edge.getSourceCell()
        const divRelated = document.getElementById('divRelated')
        const container = document.getElementById('container')

        var x1 = container.style.width.replace('px', '') / 2 - 450
        var y1 = container.style.height.replace('px', '') / 2 - 300

        divRelated.style.left = x1 + 'px'
        divRelated.style.top = y1 + 'px'
        divRelated.style.position = 'absolute'
        divRelated.style.zIndex = 7
        divRelated.style.display = 'block'
      })

      graph.on('edge:click', ({ e, x, y, edge, view }) => {})

      graph.on('edge:contextmenu', ({ e, x, y, edge, view }) => {
        const divEdgeFunc = document.getElementById('divMenu')
        divEdgeFunc.style.left = x + 'px'
        divEdgeFunc.style.top = y + 'px'
        divEdgeFunc.style.position = 'absolute'
        divEdgeFunc.style.zIndex = 5
        divEdgeFunc.style.display = 'block'

        const btnDelEdge = document.getElementById('btnDelEdge')
        btnDelEdge.parentElement.parentElement.style.backgroundColor = btnDelEdge.parentElement.style.backgroundColor = btnDelEdge.style.backgroundColor = 'white'
      })

      graph.on('edge:selected', ({ e, x, y, edge, view }) => {
        edge.attr('line/stroke', 'red')
      })

      function getTdVal(obj) {
        alert(obj.innerHTML)
      }

      function deleteEdge(obj) {
        var divEdgeFunc = document.getElementById('divMenu')
        divEdgeFunc.style = 'display:none'
        divEdgeFunc.className = 'menu_div'
        divEdgeFunc.style.zIndex = 5
      }

      document.onmousedown = function () {
        var divEdgeFunc = document.getElementById('divMenu')
        divEdgeFunc.style = 'display:none'
      }

      function closePage() {
        var divRelated = document.getElementById('divRelated')
        divRelated.style = 'display:none'
      }
    })
  }
}
</script>

<style>
html {
  font-family: sans-serif;
  -ms-text-size-adjust: 100%;
  -webkit-text-size-adjust: 100%;
}

.btn {
  float: left;
  width: auto;
  background-color: transparent;
  cursor: pointer;
  width: 100%;
  border: 0px;
  text-align: left;
}

.menu_div {
  height: 80px;
  width: 80px;
  border: 1px solid #cbcbcb;
  display: none;
  position: absolute;
  background-color: white;
}

.related_div {
  border: 1px solid #cbcbcb;
  display: none;
  position: absolute;
  background-color: white;
}

.model_div {
  height: 300px;
  width: 300px;
  background: #cbcbcb;
  border: 1px solid #cbcbcb;
}

.model_div_no {
  height: 257px;
  width: 300px;
  overflow-x: scroll;
}

.pure-table {
  border-collapse: collapse;
  border-spacing: 0;
  empty-cells: show;
  border: 0px solid #cbcbcb;
  width: 97%;
  background-color: white;
  font-size: 13px;
}

.pure-table caption {
  color: #000;
  padding: 1em 0;
  text-align: left;
}

.pure-table td,
.pure-table th {
  padding: 0.5em 1em;
  text-align: left;
}

.pure-table thead {
  background-color: #e0e0e0;
  color: #000;
  vertical-align: top;
  position: sticky;
  top: 0;
  z-index: 1;
}
</style>
