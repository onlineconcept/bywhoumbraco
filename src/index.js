import Vue from "vue";
import axios from 'axios';
import {store} from "./store";
import Vuetify from "vuetify";
import Croppa from "vue-croppa";

import 'babel-polyfill';
import '../scss/styles.scss';

Vue.use(Vuetify);
Vue.use(Croppa);
import "./PageWrap";
import "./TestComponent";
import "./Builder";
import "./Slider";
import "./Carousel";
import "./CarouselItem";
import "./Basket";
import "./CheckoutInformation";
import "./CheckoutWrap";
import "./Wallart";
import "./FPImage"
import "./AdminWrap";
import "./AdminOrders";
import "./AdminStyles";
import "./Login";
import "./RegisterUser";
import "./DesignRequest";


Vue.config.devtools = true;
new Vue({
    el: "[oc-app]",
    props: {
        labels: {
            type: Array
        },
    },
    store,
    methods: {
        getLabel(key) {
            var result = this._vnode.data.attrs.labels.filter(x=> x.Name === key)[0];

            if(result)
                return result.Value;
            return key;
        },
    },
});
