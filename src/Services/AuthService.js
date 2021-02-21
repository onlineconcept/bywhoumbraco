const axios = require('axios');
const {serverAPI} = require('../Config');
const apiClient = axios.create({
  baseURL: `${serverAPI.url}`,
  withCredentials: false,
  headers: {
	Accept: 'application/json',
	'Content-Type': 'application/json'
  }
});
export const AuthService = {
  async setHeader() {
	localStorage.getItem('authtoken', token);
	axios.defaults.headers.common['Authorization'] = "Bearer " + token.toString()
  },
  async registerUser(data){
	this.setHeader();
	var {data} = await axios.post(`/auth/register`,user);
	return data;
  },
  async login(user){
	var {data} = await axios.post(`/auth/login`,user);
	return data;
  }
};
