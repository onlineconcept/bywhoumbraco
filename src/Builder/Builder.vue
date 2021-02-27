<script>
import { Cropper } from 'vue-advanced-cropper';
import 'vue-advanced-cropper/dist/style.css';
    export default{
      name:'builder',
      components:{
        Cropper
      },
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
          cropperHeight:null,
          showAddButton:false,
          dialog:false,
          pictures:[],
          userText:'',
		  styleComments:'',
          addToBasket:false,
          selectedSize:null,
          loading:false,
          uploading:false,
          img:null,
          limitations: {
            minWidth: 50,
            minHeight: 50,
          }
        }
      },
      created() {
        this.$store.dispatch("sizes/loadSizes");

      },mounted(){
/*        if(!this.isMobile()) {
          this.cropperWidth = 472;
          this.cropperHeight = 700;
        }
        else{
          this.cropperWidth = window.innerWidth-48;
          this.cropperHeight = window.innerHeight-150;
        }*/

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
        percentsRestriction({ minWidth, minHeight, maxWidth, maxHeight, imageSize }) {
          return {
            maxWidth: (imageSize.width * (maxWidth || 100)) / 100,
            maxHeight: (imageSize.height * (maxHeight || 100)) / 100,
            minWidth: (imageSize.width * (minWidth || 0)) / 100,
            minHeight: (imageSize.height * (minHeight || 0)) / 100,
          };
        },
        rotate(angle) {
          this.$refs.cropper.rotate(angle);
        },
        change(evt){
          this.pictureAdded();
          console.log(evt)
        },
        reset() {
          this.img = null;
          this.pictureRemoved();
        },
        loadImage(event) {
          // Reference to the DOM input element
          var input = event.target;
          // Ensure that you have a file before attempting to read it
          if (input.files && input.files[0]) {
            // create a new FileReader to read this image and convert to base64 format
            var reader = new FileReader();
            // Define a callback function to run, when FileReader finishes its job
            reader.onload = (e) => {
              // Note: arrow function used here, so that "this.imageData" refers to the imageData of Vue component
              // Read image as base64 and set to imageData
              this.img = e.target.result;
            };
            // Start the reader job - read file as a data url (base64 format)
            reader.readAsDataURL(input.files[0]);
          }
        },
        isMobile() {
          var check = false;
          (function(a){if(/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino/i.test(a)||/1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(a.substr(0,4))) check = true;})(navigator.userAgent||navigator.vendor||window.opera);
          return check;
        },
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
          const self = this;
          this.myCroppa.generateBlob(
              blob => {
                // write code to upload the cropped image file (a file is a blob)
                var reader = new FileReader();
                reader.readAsDataURL(blob);
                reader.onloadend = function() {
                  var base64data = reader.result;
                  console.log(base64data);
                  self.pictures.push(base64data);
                }
              },
              'image/jpeg',
              0.8
          );



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
          this.uploading = true;
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
              this.loading = false;
              this.uploading = false;
              location.href = '/';
            });


          },
            calculatePrice(){
            let extra = 0;
            if(this.pictures.length >5 ){
                const extraPictures = this.pictures.length-5;
                extra += 100*extraPictures;
            }
                return parseFloat(this.price)+ extra;
            },
        saveImage() {
          const result = this.$refs.cropper.getResult().canvas.toDataURL();
          this.pictures.push(result);
          this.reset();
          this.dialog = false;
        },
      }
    }
</script>
<template src="./Builder.html"></template>
<style src="./Builder.scss" scoped></style>
