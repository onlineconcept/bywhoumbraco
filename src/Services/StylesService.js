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
export const StyleService = {

  async getStyles(){
	var token = localStorage.getItem('authtoken');
	const {data} = await axios.get(`/frontend/styles`);
	if(data.error) throw Error();
	return data;
  }
};
