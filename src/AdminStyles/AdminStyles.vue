<script>
  export default {
	name: "admin-styles",
	data () {
	  return {
		headers: [
		  {
			text: 'Stilart',
			align: 'left',
			value: 'name'
		  },
		  { text: 'Pris', value: 'price', align: 'right' },
		  { text: 'Oprettet', value: 'created', align: 'center' },
		  { text: 'Har tekst', value: 'hasText', align: 'center' }
		]
	  }
	},
    created() {
	  this.$store.dispatch('admin/loadStyles')
	},
    computed:{
	  stilarter(){
	    return this.$store.getters['admin/getStyles'];
      }
    }
  }
</script>
<template src="./AdminStyles.html"></template>
<style src="./AdminStyles.scss" lang="scss" scoped></style>
