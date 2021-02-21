<script>
  export default {
	name: "slider",
	data () {
	  return {
		showArrows:false,
        showArrowsOnHover:false,
	    hideDelimiters:false,
        cycle:true,
		items: [
		  {
			src: 'https://bywho.dk/Content/images/banner/new/1.jpg',
            href:"/stilarter"
		  },
		  {
			src: 'https://bywho.dk/Content/images/banner/new/2.jpg',
			href:"/stilarter"
		  },
		  {
			src: 'https://bywho.dk/Content/images/banner/new/3.jpg',
			href:"/stilarter"
		  },
		  {
			src: 'https://bywho.dk/Content/images/banner/new/4.jpg',
			href:"/stilarter"
		  },
		  {
			src: 'https://bywho.dk/Content/images/banner/new/5.jpg',
			href:"/stilarter"
		  },
		],
	  }
	}
  }
</script>

<template src="./Slider.html"></template>
