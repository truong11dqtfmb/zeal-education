import axiosClient from "./axiosClient";

//api/cartitemApi.js
class CartitemApi{
    getAll = (params) => {
        const url = '/cartitem';
        return axiosClient.get(url, {params});
    };
}

const cartitemApi = new CartitemApi();
export default cartitemApi;