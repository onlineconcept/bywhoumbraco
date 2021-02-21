<script>
  import {StyleService} from "../Services/StylesService";
  import { isMobile } from 'mobile-device-detect';
  export default {
	name: "wallart",
    props:{
	  imageUrl:{
	    required:true
      },
      headerText:{
	    required:true
      },
	  headerTextMobile:{
		required:true
	  },
      bottomText:{
	    required:true
      },
	  bottomTextMobile:{
		required:true
	  },
	  bannerTextMobile:{
	    required:true
      }
    },
    data(){
	  return {
		windowWidth:window.innerWidth,
	    url:'',
        step:1,
        horizontal:0,
        vertical:0,
        height:200,
        scrollRight:null,
        scrollLeft:null,
        posters:[],
        art:'',
        slidePosition:0,
        container:null,
		timer:null
      }
    },
	mounted() {
	  window.onresize = () => {
		this.windowWidth = window.innerWidth
	  }

	},
    async created() {
	  const self = this;
      const data = await StyleService.getStyles();
      this.posters = data;
	  this.art = this.posters[0];
	},destroyed() {
	  this.slideRight = null;
	  this.slideLeft = null;
	  if(this.timer)
	    clearTimeout(this.timer);
	},computed:{
        totalWidth(){
		  return this.$refs.slider.clientWidth;
        },
        isMobileDevice(){
			return isMobile
        }
    },
    methods:{
	  scroll_left() {
		let content = document.querySelector(".slides");
		if(content.scrollLeft > 0) {
		  content.scrollLeft -= 1;
		}
	  },
	  scroll_right() {
		let content = document.querySelector(".slides");
		content.scrollLeft += 1;
	  },
      rightStartClick(){
	    const self = this;
	    this.scrollRight = setInterval(()=> self.scroll_right(),5);
      },
      rightStopClick(){
		if(this.scrollRight) clearInterval(this.scrollRight);
      },
	  leftStartClick(){
		const self = this;
		this.scrollLeft = setInterval(()=> self.scroll_left(),5);
	  },
	  leftStopClick(){
        if(this.scrollLeft) clearInterval(this.scrollLeft);
	  },
	  scroll(e){
	    console.log(e);
      },
	  posterChange(index){
		this.art = this.posters[index];
      },
	  fileUploaded(e){
	    this.url = URL.createObjectURL(e.target.files[0]);
	    this.step = 2;
	    const self = this;
	    this.$nextTick(()=>{

	      self.timer = setTimeout(()=>{
			this.height = 200;
			this.horizontal = (this.$refs.canvas.clientWidth/2)-(this.$refs.poster.clientWidth/2);
			this.vertical = (this.$refs.frame.clientHeight/2)-(this.$refs.poster.clientHeight/2);

          },200);


        })
      },
	  frameWidth(){
		if(this.$refs.canvas) {
		  this.frameW = this.$refs.canvas.clientWidth-this.$refs.poster.clientWidth;
		  return this.frameW;
		}
		return 200;
	  },
	  frameHeight(){
		if(this.$refs.canvas) {
		  this.frameH = this.$refs.canvas.clientHeight-this.$refs.poster.clientHeight;
		  return this.frameH;
		}
		return 200
	  },
      slideRight(){
	    this.slidePosition -= 180;
      },
      slideLeft(){
		this.slidePosition += 180;
      },
      redirect(){
		window.location.href = `/stilarter/${this.art.seName}`;
      }
    }
  }
</script>

<style src="./Wallart.scss" scoped></style>
<template src="./Wallart.html"></template>
