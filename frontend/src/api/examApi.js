import axiosClient from "./axiosClient";

const examApi = {
  getAll: (params) => {
    const url = '/exam';
    return axiosClient.get(url, { params });
  },

  get: (id) => {
    const url = `/exam/${id}`;
    return axiosClient.get(url);
  },
}

export default examApi;