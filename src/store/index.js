import Vue from 'vue';
import Vuex from 'vuex'
import cart from './modules/cart'
import sizes from './modules/sizes'
import admin from './modules/admin'
import auth from './modules/auth'
import resources from './modules/resources'
Vue.use(Vuex);

export const store = new Vuex.Store({
  modules:{
    cart,
    sizes,
    admin,
    auth,
    resources
  },
  state:{
    loading:false
  },
  mutations:{},
  actions:{},
  getters:{}
  ,strict:true
});
