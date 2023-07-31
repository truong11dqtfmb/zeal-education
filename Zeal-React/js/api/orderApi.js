import axiosClient from "./axiosClient";

//api/orderApi.js
class OrderApi{
    getAll = (params) => {
        const url = '/order';
        return axiosClient.get(url, {params});
    };
}

const orderApi = new OrderApi();
export default orderApi;