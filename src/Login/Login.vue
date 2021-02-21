<script>
  import {AuthService} from "../Services/AuthService";

  export default {
	name: "login",
    data(){
	  return {
	    username:'',
        password:'',
        error:''
      }
    },
	methods:{
	  async login(){
	    try {
		  this.error = '';
		  this.$store.dispatch('auth/login',{username:this.username,password:this.password});
		}
		catch(e){
	      this.error = 'error';
	      console.log(e);
        }
	  }
	}
  }
</script>
<template src="./Login.html"></template>
<style src="./Login.scss" lang="scss" scoped></style>
