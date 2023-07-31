import axiosClient from "./axiosClient";

const courseApi = {
  getAll: (params) => {
    const url = '/course';
    return axiosClient.get(url, { params });
  },

  get: (id) => {
    const url = `/course/${id}`;
    return axiosClient.get(url);
  },
}

export default courseApi;