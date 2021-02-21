import axios from 'axios';
import {AdminService} from "../../Services/AdminService";
export default {
  namespaced: true,
  state: {
	customers:[],
	orders:[],
	styles:[]
  },
  mutations: {
	SET_ORDERS(state,payload){
	  state.orders = payload;
	},
	SET_STYLES(state,payload){
	  state.styles = payload;
	}
  },
  actions: {
	async loadOrders(context){
	   const data = await AdminService.getOrders();
	   context.commit('SET_ORDERS',data)
	},
	async loadStyles(context){
	  const data = await AdminService.getStyles();
	  context.commit('SET_STYLES',data)

	}

  },
  getters: {
	getOrders: state => state.orders,
	getCustomers: state => state.customers,
	getStyles: state => state.styles,

  }
};
