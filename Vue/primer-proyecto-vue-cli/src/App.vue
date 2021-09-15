<template>
  <img alt="Vue logo" src="./assets/logo.png">
  <HelloWorld msg="Welcome to Your Vue.js App"/>
  <input type="text" v-model="userName"/>
  <Hello :who="userName" what="Welcome" />
  <Greeting :greeting="greeting" :who="who"/>
  <button @click="newGreeting()">New Greeting</button>
  <div style="margin-top:3rem">
  Team ID: <input type="text" v-model="teamId"/>
  <InfoEquipo :id="teamId"/>
  </div>
</template>

<script>
import HelloWorld from './components/HelloWorld.vue';
import Hello from './components/Hello.vue';
import Greeting from './components/Greeting.vue';
import InfoEquipo from './components/InfoEquipo.vue';

export default {
  name: 'App',
  data() {
    return {
      userName: '',
      teamId: '',
      possibleGreetings: [
        { greeting: 'Hello', who: 'Vue.js' },
        { greeting: 'Hey', who: 'Everyone' },
        { greeting: 'Hi', who: 'JavaScript' },
      ],
      currentIndex: 0,
    };
  },
  computed: {
    currentGreeting() {
      return this.possibleGreetings[this.currentIndex];
    },
    greeting() {
      return this.currentGreeting.greeting;
    },
    who() {
      return this.currentGreeting.who;
    },
  },
  methods: {
    newGreeting() {
      this.currentIndex = this.currentIndex === (this.possibleGreetings.length - 1)
        ? 0
        : this.currentIndex + 1;
    },
  },
  components: {
    HelloWorld,
    Hello,
    Greeting,
    InfoEquipo,
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
