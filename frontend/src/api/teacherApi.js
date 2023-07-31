import axiosClient from "./axiosClient";

const teachertApi = {
  getAll: (params) => {
    const url = '/teacher';
    return axiosClient.get(url, { params });
  },

  get: (id) => {
    const url = `/teacher/${id}`;
    return axiosClient.get(url);
  },
}

export default teachertApi;