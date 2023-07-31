import React from 'react';
import logo from './logo.svg';
import './App.css';
// import courseApi from 'api/courseApi';

function App() {
  
  // const [courseList, setCourseList] = useState([]);

  // useEffect(() => {
  //   const fetchCourseList = async () => {
  //     try {
  //       const params = {
  //         _page: 1,
  //         _limit: 10,

  //       };
  //       const response = await courseApi.getAll(params);
  //       console.log(response);
  //       setCourseList(response.data);
  //     } catch (error) {
  //       console.log('Failed to fetch product list: ', error);
  //     }
  //   }

  //   fetchCourseList();
  // }, []);


  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
