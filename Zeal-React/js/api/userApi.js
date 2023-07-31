import axiosClient from "./axiosClient";

//api/userApi.js
class UserApi{
    getAll = (params) => {
        const url = '/user';
        return axiosClient.get(url, {params});
    };
}

const userApi = new UserApi();
export default userApi;