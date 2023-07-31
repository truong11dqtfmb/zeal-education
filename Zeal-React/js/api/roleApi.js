import axiosClient from "./axiosClient";

//api/roleApi.js
class RoleApi{
    getAll = (params) => {
        const url = '/role';
        return axiosClient.get(url, {params});
    };
}

const roleApi = new RoleApi();
export default roleApi;