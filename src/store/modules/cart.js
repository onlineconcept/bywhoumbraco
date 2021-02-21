import axios from 'axios';
export default {
  namespaced: true,
  state: {
    cartlines: [],
    customerId: localStorage.getItem('customerId') || null,
    show:false,
    quantityLoading:false,
    customer: {
      firstname: '',
      lastname: '',
      address: '',
      zipcode: '',
      city: '',
      email: '',
      phone: ''
    },
    errors:[]
  },
  mutations: {
    SET_CARTLINES(state,payload){

      state.cartlines = payload;
    },
    SET_SHOW_CART(state,payload){
      state.show = payload;
    },
    SET_QUANTITY_LOADING(state, payload){
      state.quantityLoading = payload;
    },
    SET_FIRSTNAME(state,payload){
      state.customer.firstname = payload;
    },
    SET_LASTNAME(state,payload){
      state.customer.lastname = payload;
    },
    SET_ADDRESS(state,payload){
      state.customer.address = payload;
    },
    SET_ZIPCODE(state,payload){
      state.customer.zipcode = payload;
    },
    SET_CITY(state,payload){
      state.customer.city = payload;
    },
    SET_PHONE(state,payload){
      state.customer.phone = payload;
    },
    SET_EMAIL(state,payload){
      state.customer.email = payload;
    },
    SET_FORM_ERROR(state,payload){
      state.errors = payload;
    },
    SET_CUSTOMER(state, payload){
      state.customer = payload;
    }

  },
  actions: {
    loadCartItems(context,payload){
      axios.get("/cart/cartlines?customerId="+ payload).then(({data}) => {
        return context.commit("SET_CARTLINES",data);
      });
    },
<<<<<<< HEAD
    async updateCustomer({state}, payload) {

      axios.post("/cart/updatecustomer", {customer: payload ? payload:state.customer, customerId: state.customerId});
=======
    async updateCustomer(context){
      await axios.post(`/cart/updatecustomer`,{
        customerId: context.state.customerId,
        customer: context.state.customer
      });
>>>>>>> 8de6f2e2c83ad2cca316a4f5f82c84b059351f82
    },
    createCart(context){
      axios.post("/cart/createcart").then(({data})=>{
        localStorage.setItem("customerId", data);
      })
    },
    async addToCart(context, item){
      const {data} = await axios.post("/cart/addtocart",item);
      return await context.dispatch("loadCartItems",data.customerId);
    },
    increment(context, line){
      context.commit("SET_QUANTITY_LOADING", true);
      axios.post(`/cart/product/increment/${line}`,{}).then(()=>{
        context.commit("SET_QUANTITY_LOADING", false);
        context.dispatch("loadCartItems",context.getters.getCustomerId)
      }).catch(()=> context.commit("SET_QUANTITY_LOADING", false))
    },
    decrement(context,line){
      context.commit("SET_QUANTITY_LOADING", true);
      axios.post(`/cart/product/decrement/${line}`,{}).then(()=>{
        context.commit("SET_QUANTITY_LOADING", true);
        context.dispatch("loadCartItems",context.getters.getCustomerId)
      }).catch(()=> context.commit("SET_QUANTITY_LOADING", false))
    }

  },
  getters: {
    getCartLines: state => state.cartlines,
    getCustomerId: state => state.customerId,
    showCart: state => state.show,
    getCustomer: state => state.customer,
    getErrors: state => state.errors
  }
};
