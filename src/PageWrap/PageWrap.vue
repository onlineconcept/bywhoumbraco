<script>
  export default {
    name: "page-wrap",
      props:{
        checkout:{
            type: Boolean,
            default:false
        }
      },
    data(){
      return {
        drawer:false
      }
    },
    async mounted() {
       if(!this.$store.getters["cart/getCustomerId"]){
           await this.$store.dispatch("cart/createCart");

       }
	  await  this.$store.dispatch("cart/loadCartItems",this.$store.getters["cart/getCustomerId"]);
    },
    methods:{
      openDrawer(){
        this.drawer = true
      },
	  showBasket(){
		this.$store.commit("cart/SET_SHOW_CART",true);
      },
	  stylesPass(){
        location.href = '/stilarter'
      },
      getLabel(key){
         const resource = this.resources.filter(x=> x.name === key)[0];
         if(resource)
             return resource.value;
         return key;

      }
    }
  }
</script>
<template src="./PageWrap.html"></template>
