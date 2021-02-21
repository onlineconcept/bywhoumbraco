
import axios from 'axios';
export default{

    namespaced:true,
    state:{
        resources:[]
    },
    mutations:{
        SET_RESOURCES(state,payload){
            state.resources = payload;
        }

    },
    actions:{
        loadResources(context){
            axios.get("/resources").then(({data})=>{
                context.commit("SET_RESOURCES",data);
            })
        }
    },
    getters:{
        getResources: (state) => (id) => {
            return state.resources.find(r => r.name === id)
        }
    }
}
