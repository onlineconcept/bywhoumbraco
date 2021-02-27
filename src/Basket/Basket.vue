<script>
    import axios from 'axios';
  export default {
	name: "basket",
    props:['checkout','step'],
    data(){
	  return {
	    paymentWindow:null,
        fetchingForm:false
      }
    },
    created(){
	  if(localStorage.getItem("customerInfo")){
	    const cus = JSON.parse(localStorage.getItem("customerInfo"));
	    this.$store.commit("cart/SET_CUSTOMER", cus);
      }
	  if(this.step === 2){
	    this.fetchingForm = true;
		axios.get(`/checkout/paymentwindow/${this.$store.getters['cart/getCustomerId']}`).then(({data})=>{
		  this.paymentWindow = data.paymentWindow;
		  this.fetchingForm = false;
		}).catch(err=> {console.error(err); this.fetchingForm = false;})
      }
    },
    computed:{
	  show(){
	    if(this.checkout)
	      return true;
	    return this.$store.getters['cart/showCart'];
      },
      cartlines(){
        return this.$store.getters['cart/getCartLines']
      },
      total(){
	    const lines = this.cartlines;
	    let total = 0;
	    lines.map(x=> total += (x.quantity*x.price));
	    return total;
      },
	  customer(){
		return this.$store.getters["cart/getCustomer"];
	  }

    },
    methods:{
	  closeMenu(){
	    this.$store.commit("cart/SET_SHOW_CART",false);
      },
      decrement(line){
		this.$store.dispatch("cart/decrement",line);
      },
      increment(line){
        this.$store.dispatch("cart/increment",line);
      },
      gotoPayment(){
	    let error = [];
	    console.log(this.customer.firstname.trim().length)
	    if(this.customer.firstname.trim().length === 0 || this.customer.firstname.trim().length > 30)
        {
          error.push("Fornavn skal udfyldes og må ikke være over 30 tegn.");
        }
		if(this.customer.lastname.trim().length === 0 || this.customer.lastname.trim().length > 30)
		{
		  error.push("Efternavn skal udfyldes og må ikke være over 30 tegn.");
		}
		if(this.customer.address.trim().length === 0 || this.customer.address.trim().length > 90)
		{
		  error.push("Adresse skal udfyldes og må ikke være over 90 tegn.");
		}
		if(this.customer.zipcode.trim().length !== 4)
		{
		  error.push("Postnummer skal udfyldes og skal være 4 tal.");
		}
		if(this.customer.city.trim().length === 0 || this.customer.city.trim().length > 30)
		{
		  error.push("By skal udfyldes og må ikke være over 30 tegn.");
		}
		if(this.customer.phone.trim().length !== 8)
		{
		  error.push("Telefon nummer skal udfyldes og være 8 tegn.");
		}
		if(this.customer.email.trim().length === 0 || this.customer.email.trim().length > 100)
		{
		  error.push("E-Mail skal udfyldes og må ikke være over 100 tegn.");
		}
		if(!/.+@.+/.test(this.customer.email)){
		  error.push("Din email er ikke indtastet korrekt");
        }
		if(error.length === 0) {
      localStorage.setItem("customerInfo",JSON.stringify(this.customer));
		  window.location.href = "/checkout/payment";
		}else{
		  this.$store.commit("cart/SET_FORM_ERROR", error);
        }
      }
    }

  }
</script>
<template src="./Basket.html"></template>
<style src="./Basket.scss" lang="scss" scoped></style>
<!---->
