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
export const AdminService = {

  async getOrders(){
	  var token = localStorage.getItem('authtoken');
	  const {data} = await axios.get(`/admin/orders/getorders?token=${token}`);
	  if(data.error) throw Error();
	  return data;
  },
  async getStyles(){
		var token = localStorage.getItem('authtoken');
		const {data} = await axios.get(`/admin/styles/getstyles?token=${token}`);
		if(data.error) throw Error();
		return data;

  }
};
