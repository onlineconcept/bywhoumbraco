<script>
    import AdminOrders from "../AdminOrders/AdminOrders";
    import AdminStyles from "../AdminStyles/AdminStyles";
    import Login from "../Login/Login";
  export default {
    name: "admin-wrap",
    components:{
      AdminOrders,
      AdminStyles,
      Login
    },
    data(){
      return {
        visible:1
      }
    },
    computed:{

      orders()
      {
          return this.$store.getters["admin/getOrders"];
      },
      customers(){
          return this.$store.getters["admin/getCustomers"];
      },
      styles()
      {
          return this.$store.getters["admin/getStyles"];
      },
      isAuth(){
        return this.$store.getters["auth/getAuth"];
      }
    },
    mounted() {

    },
    methods:{
        logout(){
          console.log('logout');
        }
    }
  }
</script>
<template src="./AdminWrap.html"></template>
