<template>
<div class="container">
    <div class="row text-center">
        <span class="h1">Login</span>
    </div>
    <div class="row my-3">
        <div class="col-12">
        Username: <input type="text" class="form-control" v-model="username">
        </div>
    </div>
    <div class="row my-3">
        <div class="col-12">
        Password: <input type="password" class="form-control" v-model="password">
        </div>
    </div>
    <div style="color: red" v-show="incorrectLogin">
        Incorrect credentials
    </div>
    <div class="row my-3 justify-content-center">
        <div class="col-12 col-md-6 d-grid">
        <button class="btn btn-primary" @click="login()">Login</button>
        </div>
    </div>
</div>
</template>

<script>
export default {
  data() {
    return {
      username: '',
      password: '',
      incorrectLogin: false,
    };
  },
  methods: {
    login() {
      if (this.username === 'cuit@email.com' && this.password === '123123') {
        this.$router.push({ name: 'Products', params: { userName: this.username, loginSuccessful: true } });
      } else {
        this.incorrectLogin = true;
      }
    },
  },
};
</script>

<style>

</style>
