import axios from 'axios';
export default{
    namespaced:true,
    state:{
        sizes:[]
    },
    mutations:{
        SET_SIZES(state,payload){
            console.log(payload,"setting size")
            state.sizes = payload;
        }

    },
    actions:{
        loadSizes(context){
            axios.get("/sizes/all").then(({data})=>{
                context.commit("SET_SIZES",data);
            })
        }
    },
    getters:{
        getSizes:state => state.sizes
    }
}
