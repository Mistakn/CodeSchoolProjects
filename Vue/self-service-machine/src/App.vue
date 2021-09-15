<template>
  <div id="app">
    <SelfServiceMachine />
  </div>
</template>

<script>

import SelfServiceMachine from './components/SelfServiceMachine.vue';

export default {
  name: 'App',
  components: {
    SelfServiceMachine,
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
