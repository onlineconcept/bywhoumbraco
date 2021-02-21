import axios from 'axios';
import {AuthService} from "../../Services/AuthService";
export default {
  namespaced: true,
  state: {
	isAuth: localStorage.getItem('authtoken') !== null ? true: false
  },
  mutations: {
	SET_AUTH(state,payload){
	  state.isAuth = payload;
	}
  },
  actions: {
	async login(context,payload){
	  try{
		const data = await AuthService.login({username: payload.username, password: payload.password});
		if (data) {
		  localStorage.setItem('authtoken', data.token);
		  context.commit('SET_AUTH',true);
		}
		else{
		  context.commit('SET_AUTH',false);
		}
	  }catch (e) {
		console.error(e)
	  }
	},
	async register(context){

	},
	async logout(context){
	  localStorage.removeItem('authtoken');
	  context.commit('SET_AUTH',false);
	}


  },
  getters: {
	getAuth: state => state.isAuth
  }
};
