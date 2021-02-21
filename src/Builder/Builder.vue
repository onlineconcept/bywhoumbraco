<script>

    export default{
      name:'builder',
      props:{
        name:{
          required:true,
          type:String
        },
        price:{
          required:true,
          type:Number
        },
        amount:{
          required:true,
          type:String
        },
        text:{
          required:true,
          type:Boolean
        },
        description:{
          required:true,
          type:String
        },
        image:{
          required:true,
          type:String
        },
        id:{
          required:true,
          type:String
        }
      },
      data(){
        return {
          building: false,
          myCroppa:{},
          cropperWidth:null,
          showAddButton:false,
          dialog:false,
          pictures:[],
          userText:'',
		  styleComments:'',
          addToBasket:false,
          selectedSize:null,
          loading:false
        }
      },
      created() {
        this.$store.dispatch("sizes/loadSizes");

      },mounted(){
        this.cropperWidth = this.$refs.croppa.clientWidth-25;
      },
      computed:{
          sizes(){
              return this.$store.getters["sizes/getSizes"];
          },
          textEntered(){
              if(this.text)
                  if(!this.userText)
                      return false;

              return true;
          },
          picturesAdded(){
            return this.pictures.length !== 0;
          }
      },
      methods:{
        startBuilding(){
            this.building = true;
            window.scrollTo(0,0);


        },
        pictureAdded(){
            this.showAddButton = true;
        },
        pictureRemoved(){
            this.showAddButton = false;
        },
        pictureAdd(){
            this.pictures.push(this.myCroppa.generateDataUrl());
            this.myCroppa.remove();
            this.dialog = false;
        },
          deletePicture(index){
            const result = confirm("Er du sikker på du vil slette billedet ?")
            if(result) {
                const arr = [...this.pictures];
                arr.splice(index, 1);
                console.log(arr);
                this.pictures = arr;
            }
          },
          selectSize(id){
            this.selectedSize = id;
          },
          addStyleToBasket(){
            var data = {
                pictures: this.pictures,
                sizeId: this.selectedSize,
                styleId: this.id,
                text: this.userText,
			    styleComments:this.styleComments,
                customerId:this.$store.getters["cart/getCustomerId"]
            };
            this.loading = true;
            this.$store.dispatch("cart/addToCart", data).then(()=>{
              location.href = '/';
            });
            this.loading = false;

          },
            calculatePrice(){
            let extra = 0;
            if(this.pictures.length >5 ){
                const extraPictures = this.pictures.length-5;
                extra += 100*extraPictures;
            }
                return parseFloat(this.price)+ extra;
            }
      }
    }
</script>
<template src="./Builder.html"></template>
<style src="./Builder.scss"></style>
