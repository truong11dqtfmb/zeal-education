import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

//component
import Main from './components/Main';
import Course from './components/Course';
import Login from './components/Login';


function App() {
  return (
    <Router>
      <div className="container">
        <Routes>
          <Route exact path='/' element={<Main />}></Route>
          <Route exact path='/course' element={<Course />}></Route>
          <Route exact path='/login' element={<Login />}></Route>
        </Routes>
      </div>
    </Router>

  );
}

export default App;
