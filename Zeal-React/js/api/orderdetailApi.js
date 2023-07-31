import axiosClient from "./axiosClient";

//api/orderdetailApi.js
class OrderdetailApi{
    getAll = (params) => {
        const url = '/orderdetail';
        return axiosClient.get(url, {params});
    };
}

const orderdetailApi = new OrderdetailApi();
export default orderdetailApi;