import axiosClient from "./axiosClient";

const cartitemApi = {
  getAll: (params) => {
    const url = '/cartitem';
    return axiosClient.get(url, { params });
  },

  get: (id) => {
    const url = `/cartitem/${id}`;
    return axiosClient.get(url);
  },
}

export default cartitemApi;