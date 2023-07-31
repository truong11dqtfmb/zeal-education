import axiosClient from "./axiosClient";

//api/examApi.js
class ExamApi{
    getAll = (params) => {
        const url = '/exam';
        return axiosClient.get(url, {params});
    };
}

const examApi = new ExamApi();
export default examApi;