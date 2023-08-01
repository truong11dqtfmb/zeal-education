import axiosClient from "./axiosClient";

const orderApi = {
  getAll: (params) => {
    const url = '/order';
    return axiosClient.get(url, { params });
  },

  get: (id) => {
    const url = `/order/${id}`;
    return axiosClient.get(url);
  },
}

export default orderApi;