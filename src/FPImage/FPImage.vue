<script>
    export default{
      name:'fp-image',
      props:{
        buttonText:{
          required:true
        },
        bannerText:{
          required:true
        },
		bannerTextMobile:{
		  required:true
		},
		bannerImage:{
          required:true
        },
        bannerUrl:{
          required:true
        }
      },
      data(){
        return {
		  windowWidth:window.innerWidth
        }
      },
	  mounted() {
		window.onresize = () => {
		  this.windowWidth = window.innerWidth
		}


              console.log(this.$root);

	  },
      methods:{
        redirectTo(){
          window.location.href = this.bannerUrl;
        }
      }
    }
</script>
<template src="./FPImage.html"></template>
<style src="./FPImage.scss" lang="scss" scoped></style>
