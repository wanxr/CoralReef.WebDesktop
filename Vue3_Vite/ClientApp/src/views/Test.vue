<template>
  <div>
    <ElButton type="success" @click="queryData('/api/WeatherForecast/GetWeather')">GetWeather</ElButton>
    <ElButton type="success" @click="queryData('/api/WeatherForecast/GetWeatherAllowAnonymous')">GetWeatherAllowAnonymous</ElButton>
  </div>
</template>
<script setup>
function queryData(url) {
  window.getRequest(url)
}
</script>
<style lang=""></style>
