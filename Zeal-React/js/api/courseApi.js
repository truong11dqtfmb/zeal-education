import axiosClient from "./axiosClient";

//api/courseApi.js
class CourseApi{
    //Handles here
    getAll = (params) => {
        const url = '/course';
        return axiosClient.get(url, {params});
    };

    get = (id) =>{
        const url = `/course/${id}`;
        return axiosClient.get(url);
    }
}

const courseApi = new CourseApi();
export default courseApi;