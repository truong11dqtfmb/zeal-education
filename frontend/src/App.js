import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

//component
import Main from './components/Main';
import Course from './components/Course';
import Login from './components/Login';
import Cart from './components/Cart';




function App() {
  return (
    <Router>
      <div className="container">
        <Routes>
          <Route exact path='/' element={<Main />}></Route>
          <Route exact path='/course' element={<Course />}></Route>
          <Route exact path='/login' element={<Login />}></Route>
          <Route exact path='/cart' element={<Cart />}></Route>
        </Routes>
      </div>
    </Router>

  );
}

export default App;
