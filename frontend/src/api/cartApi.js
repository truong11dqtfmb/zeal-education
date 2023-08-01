import axiosClient from "./axiosClient";

const cartApi = {
  getAll: (params) => {
    const url = '/cart';
    return axiosClient.get(url, { params });
  },

  get: (id) => {
    const url = `/cart/${id}`;
    return axiosClient.get(url);
  },
}

export default cartApi;