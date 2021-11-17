<template>
  <div class="login">
    <h3 class="title">欢迎使用SparkNest</h3>
    <div class="grid-content bg-purple-light">
      <el-form ref="loginForm" status-icon :rules="rules" size="small" label-width="50px" :model="loginInfo">
        <el-form-item label="账号" prop="name">
          <el-input placeholder="请输入用户名" v-model="loginInfo.name" autocomplete="off"></el-input>
        </el-form-item>
        <el-form-item label="密码" prop="password">
          <el-input placeholder="请输入密码" v-model="loginInfo.password" show-password autocomplete="off"></el-input>
        </el-form-item>
        <el-form-item>
          <el-col :span="18" style="margin-right: 11px;">
            <el-select v-model="loginInfo.projName" filterable clearable placeholder="请选择">
              <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value"> </el-option>
            </el-select>
          </el-col>
          <el-col :span="6">
            <el-button type="primary" icon="el-icon-refresh" :loading="loading" style="padding-top: 5px; padding-bottom: 5px;"></el-button>
          </el-col>
        </el-form-item>
        <el-form-item>
          <el-button id="submit" type="primary" @click="submitForm">登录</el-button>
          <el-button id="reset" @click="resetForm">重置</el-button>
        </el-form-item>
      </el-form>
    </div>
  </div>
</template>

<script>
import { reactive, ref } from 'vue'
import { login } from '@/api/login/index'
import router from '@/router/index'

export default {
  name: 'Login',
  setup(props) {
    const loginForm = ref(null)
    const loginInfo = reactive({
      name: 'admin',
      password: 'password',
      projName: ''
    })
    const rules = {
      name: [{ required: true, message: '请输入用户名', trigger: 'blur' }],
      password: [{ required: true, message: '请输入密码', trigger: 'blur' }]
      // projName: [{ required: true, message: '请选择项目', trigger: 'blur' }]
    }
    const validate = () => {
      let result = false
      loginForm.value.validate((valid) => {
        result = valid
      })
      return result
    }
    const submitForm = () => {
      if (validate()) {
        // login(loginInfo).then((resp) => {
        //   if (resp) {
        //     const userToken = resp.data.token
        //     window.sessionStorage.setItem('Authorization', userToken)
        //     // this.$store.commit('changeLogin', { Authorization: userToken })
        //     router.replace('/home')
        //   } else {
        //     // updateCode();
        //   }
        // })
        router.replace('/home')
      }
    }
    const resetForm = () => {
      loginForm.value.resetFields()
    }
    return {
      loginForm,
      loginInfo,
      rules,
      validate,
      submitForm,
      resetForm,
      options: [
        {
          value: '选项1',
          label: '黄金糕'
        },
        {
          value: '选项2',
          label: '双皮奶'
        },
        {
          value: '选项3',
          label: '蚵仔煎'
        },
        {
          value: '选项4',
          label: '龙须面'
        },
        {
          value: '选项5',
          label: '北京烤鸭'
        }
      ],
      loading: false
    }
  }
}
</script>

<style>
.el-select-dropdown {
  overflow: auto !important;
  /* max-height: 50px !important; */
  height: 70px !important;
}
</style>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style lang="scss" scoped>
.login {
  width: 420px;
  margin: 34px auto;
  // box-shadow: 0px 0px 10px 5px #c2c2c2;
  padding: 15px 70px;
  border-radius: 5px;
  box-sizing: border-box;
  .title {
    margin-top: 0px;
    margin-bottom: 20px;
    font-weight: bold;
    text-align: center;
  }
  .el-form-item:last-child {
    margin-bottom: 0px;
  }
  #submit {
    float: left;
  }
  #reset {
    float: right;
  }
}
</style>
