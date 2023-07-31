import axiosClient from "./axiosClient";

const orderdetailApi = {
  getAll: (params) => {
    const url = '/orderdetail';
    return axiosClient.get(url, { params });
  },

  get: (id) => {
    const url = `/orderdetail/${id}`;
    return axiosClient.get(url);
  },
}

export default orderdetailApi;