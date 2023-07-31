import axiosClient from "./axiosClient";

//api/teacherApi.js
class TeacherApi{
    getAll = (params) => {
        const url = '/teacher';
        return axiosClient.get(url, {params});
    };
}

const teacherApi = new TeacherApi();
export default teacherApi;