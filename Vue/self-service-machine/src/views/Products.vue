<template>
<div>
    <div class="row text-center">
          <span class="h2">Welcome {{$route.params.userName}}</span>
    </div>
    <SelfServiceMachine />
</div>
</template>

<script>
import SelfServiceMachine from '../components/SelfServiceMachine.vue';

export default {
  components: {
    SelfServiceMachine,
  },
  created() {
    const logginSuccessful = this.$route.params.loginSuccessful;
    if (!logginSuccessful) {
      this.$router.push({ name: 'Login' });
    }
  },
};
</script>

<style>

</style>
