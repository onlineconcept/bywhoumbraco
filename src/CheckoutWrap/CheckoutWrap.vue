<script>
  export default {
	name: "checkout-wrap",
    mounted() {
	  if(!this.$store.getters["cart/getCustomerId"]){
		this.$store.dispatch("cart/createCart");

	  }
	  this.$store.dispatch("cart/loadCartItems",this.$store.getters["cart/getCustomerId"]);
	}
  }
</script>
<template src="./CheckoutWrap.html"></template>
<style src="./CheckoutWrap.scss" lang="scss" scoped></style>

