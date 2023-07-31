import logo from './logo.svg';
import './App.css';

function App() {
  // import courseApi from "./api/courseApi";

// function Main() {
//     const [courseList, setCourseList] = useState([]);

//     useEffect(() => {
//         const fetchCourseList = async () => {
//             try {
//                 //const params = {
//                 //    _page: 1,
//                 //    _limit: 10,
//                 // };
//                 const response = await courseApi.getAll();//<= Truyền params
//                 console.log(response);
//                 setCourseList(response.data);
//             }catch(error){
//                 console.log('Failed to fetch course list: ',error);
//             }
//         }
//         fetchCourseList();
//     },[]);
// }
// export default Main ;

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
