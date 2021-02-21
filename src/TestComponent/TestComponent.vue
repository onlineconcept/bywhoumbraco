<script>
export default {
  name: "test-component",
  data() {
    return {
      msg: "Test component here",
      cart: []
    };
  },
  created() {
    this.cart = this.$store.getters["cart/getCartLines"];
  }
};
</script>
<template src="./TestComponent.html"></template>
