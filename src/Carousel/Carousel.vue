<script>

  export default {
	name: "bywho-slider",
    data(){
	  return {
		selectedSlide:1,
        hover:false,
	    items:[
		  {
			src: 'https://bywho.dk/Content/images/banner/new/1.jpg',
			href:"/stilarter",
			id:1
		  },
		  {
			src: 'https://bywho.dk/Content/images/banner/new/2.jpg',
			href:"/stilarter",
			id:2
		  },
		  {
			src: 'https://bywho.dk/Content/images/banner/new/3.jpg',
			href:"/stilarter",
            id:3
		  },
		  {
			src: 'https://bywho.dk/Content/images/banner/new/4.jpg',
			href:"/stilarter",
			id:4
		  },
		  {
			src: 'https://bywho.dk/Content/images/banner/new/5.jpg',
			href:"/stilarter",
			id:5
		  },
        ]
      }
    },
    created(){
	  setInterval(()=>{
	    if(!this.hover) {
		  this.nextSlide();
		}
      },4000)
    }
    ,
    methods:{
	  prevSlide(){
	    if(this.selectedSlide-1 === 0)
	      this.selectedSlide = this.items.length;
	    else
	      this.selectedSlide = this.selectedSlide-1;
      },
      nextSlide(){
	    if(this.selectedSlide+1 > this.items.length)
	      this.selectedSlide = 1;
	    else
	      this.selectedSlide = this.selectedSlide +1;
      },
      hoverImage(value){
	    this.hover = value;
      }
    }
  }
</script>

<template src="./Carousel.html"></template>
<style lang="scss" scoped>

</style>
