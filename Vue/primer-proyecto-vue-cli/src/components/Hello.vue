<template>
  <div>
      <h1>Hello {{ who }}! {{ what }}</h1>
        </div>
</template>

<script>
export default {
  props: {
    who: String,
    what: String,
  },
};
</script>
