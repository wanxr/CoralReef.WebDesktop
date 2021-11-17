<template>
  <div class="test">
    <ElButton type="success" @click="queryData('/api/WeatherForecast/GetWeather')">GetWeather</ElButton>
    <ElButton type="success" @click="queryData('/api/WeatherForecast/GetWeatherAllowAnonymous')">GetWeatherAllowAnonymous</ElButton>
    <el-table :data="tableData" stripe style="width: 100%">
      <el-table-column prop="date" label="Date" width="300" />
      <el-table-column prop="temperature" label="Temperature" />
      <el-table-column prop="summary" label="Summary" />
    </el-table>
  </div>
</template>
<script>
import { ref } from 'vue'

export default {
  name: 'Test',
  setup(props) {
    let tableData = ref([])
    const queryData = (url) => {
      window.getRequest(url).then((response) => {
        tableData.value = response.data
      })
    }
    return {
      tableData,
      queryData
    }
  }
}
</script>

<style lang="scss">
.test {
  width: 800px;
  margin: 50px auto;
  .el-table {
    margin-top: 20px;
  }
}
</style>
