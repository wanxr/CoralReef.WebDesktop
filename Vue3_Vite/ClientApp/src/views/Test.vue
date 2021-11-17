<template>
  <div>
    <ElButton type="success" @click="queryData">请求数据</ElButton>
  </div>
</template>
<script setup>
function queryData() {
  window.getRequest('/api/WeatherForecast')
}
</script>
<style lang=""></style>
