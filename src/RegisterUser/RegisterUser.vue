<script>
  import {AdminService} from "../Services/AdminService";
  import {AuthService} from "../Services/AuthService";

  export default {
	name: "register-user",
    data(){
	  return {
	    username:'',
        password:''
      }
    },
    methods:{
	  async register(){
	    const {data} = await AuthService.registerUser({username:this.username,password:this.password});
      }
    }
  }
</script>
<template src="./RegisterUser.html"></template>
<style src="./RegisterUser.scss" scoped lang="scss"></style>
