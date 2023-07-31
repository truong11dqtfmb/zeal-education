// api//axiosClient.js
import axios from "axios";
import queryString from "queryString";

// Setup default config for http requests here
const axiosClientConfig = axios.create({
    baseURL: "http://localhost",
    headers: {
        'Content-Type': 'application/json',
    },
    paramsSerializer: params => queryString.stringify(params),
});

axiosClientConfig.interceptors.request.use(async(config)=>{
    // Handle token here...
    return config;
})

axiosClient.interceptors.response.use((response) => {
    if (response && response.data) {
        return response.data;
    }
    return response.data;
}, (error)=>{
    // Handle error...
    throw error;
});

export default axiosClient; 
