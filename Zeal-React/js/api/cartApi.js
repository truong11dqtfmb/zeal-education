import axiosClient from "./axiosClient";

//api/cartApi.js
class CartApi{
    getAll = (params) => {
        const url = '/cart';
        return axiosClient.get(url, {params});
    };
}

const cartApi = new CartApi();
export default cartApi;