<script>
  //https://dawa.aws.dk/adgangsadresser?autocomplete&q=
  //https://dawa.aws.dk/postnumre/autocomplete?q=6700
  import axios from 'axios';
  export default {
	name: "checkout-information",
    props:["step"],
    data(){
	  return {
	    addresses:[],
		firstnameRules: [
		  v => !!v || 'Fornavn skal udfyldes',
		  v => v.length <= 30 || 'Fornavn skal være under 30 tegn'
		],

		lastnameRules: [
		  v => !!v || 'Efternavn skal udfyldes',
		  v => v.length <= 30 || 'Efternavn skal være under 30 tegn'
		],

		addressRules: [
		  v => !!v || 'Adresse skal udfyldes',
		  v => v.length <= 90 || 'Adresse skal være under 90 tegn'
		],

		zipcodeRules: [
		  v => !!v || 'Postnummer skal udfyldes',
		  v => v.length === 4 || 'Postnummer skal være 4 tegn'
		],

		cityRules: [
		  v => !!v || 'By skal udfyldes',
		  v => v.length <= 30 || 'By skal være under 30 tegn'
		],

		phoneRules: [
		  v => !!v || 'Telefonnummer skal udfyldes',
		  v => v.length === 8 || 'Telefonnummer skal være 8 tegn'
		],

		emailRules: [
		  v => !!v || 'E-mail skal udfyldes',
		  v => /.+@.+/.test(v) || 'E-mail er ikke korrekt udfyldt',
          v =>  v.length < 100 || 'E-mail må maks være 100 tegn'
		]
      }

    },created() {
	    if(this.step === 2){
	        var customer = JSON.parse(localStorage.getItem('customerInfo'));
	        this.updateCustomer(customer);
        }
      },destroyed() {
	    this.updateCustomer();

      },
    computed:{
	  customer(){
	   	      return this.$store.getters["cart/getCustomer"];
      },
      errors(){
	    return this.$store.getters['cart/getErrors'];
      }
    },
    methods:{
	  async getAddress(){
	    const {data} = await axios.get(`https://dawa.aws.dk/adgangsadresser?autocomplete&q=${this.address}`);
      },
      async updateCustomer(customer){
	      if(customer) {
              this.$store.dispatch('cart/updateCustomer',customer);
          }else {
              this.$store.dispatch('cart/updateCustomer',null);
          }
      },
      async updateFirstname(val){
        await axios.post('/tello',{});
	    this.$store.commit("cart/SET_FIRSTNAME",val)

      },
	  async updateLastname(val){

		this.$store.commit("cart/SET_LASTNAME",val)

	  },
	  async updateAddress(val){

		this.$store.commit("cart/SET_ADDRESS",val)

	  },
	  async updateZipcode(val){

		this.$store.commit("cart/SET_ZIPCODE",val)

	  },
	  async updateCity(val){

		this.$store.commit("cart/SET_CITY",val)

	  },
	  async updatePhone(val){

		this.$store.commit("cart/SET_PHONE",val)

	  },
	  async updateEmail(val){
		  this.$store.commit("cart/SET_EMAIL",val)
	  }
    }
  }
</script>
<template src="./CheckoutInformation.html"></template>
<style src="./CheckoutInformation.scss" lang="scss" scoped></style>
