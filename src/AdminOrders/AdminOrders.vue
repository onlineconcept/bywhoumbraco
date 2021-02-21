<script>
  export default {
	name: "admin-orders",
	data () {
	  return {
		headers: [
		  {
			text: 'Dessert (100g serving)',
			align: 'left',
			sortable: false,
			value: 'name'
		  },
		  { text: 'Calories', value: 'calories' },
		  { text: 'Fat (g)', value: 'fat' },
		  { text: 'Carbs (g)', value: 'carbs' },
		  { text: 'Protein (g)', value: 'protein' },
		  { text: 'Iron (%)', value: 'iron' }
		]

	  }
	},
    created() {
	  this.$store.dispatch('admin/loadOrders').catch(e=>{
	    this.$store.dispatch('auth/logout');
      })
	},
    computed:{
	  orders(){
	    return this.$store.getters['admin/getOrders'];
      }
    }
  }
</script>
<template src="./AdminOrders.html"></template>
<style src="./AdminOrders.scss" lang="scss" scoped></style>
