import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import axios from 'axios'


export default function
    Login() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const handleEmail = (e) => {
        setEmail(e.target.value);
    }

    const handlePassword = (e) => {
        setPassword(e.target.value);
    }

    const handleApi = () => {
        console.log({ email, password });
        axios.post('https://localhost:7215/api/Auth/login', {
            email: email,
            password: password
        })
        .then(result => {
            console.log(result,"result===");
        })
        
        .catch(err => {
            console.error(err);
        })
    }

    return (
        <div>
            <nav className="navbar navbar-expand-lg bg-white navbar-light shadow sticky-top p-0">
                <Link to='/' class="navbar-brand d-flex align-items-center px-4 px-lg-5">
                    <h2 className="m-0 text-primary"><i className="fa fa-book me-3"></i>Zeal Education Manager</h2>
                </Link>
                <button type="button" class="navbar-toggler me-4" data-bs-toggle="collapse" data-bs-target="#navbarCollapse">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarCollapse">
                    <div className="navbar-nav ms-auto p-4 p-lg-0">
                        <Link to='/' className="nav-item nav-link active">Home</Link>
                        <a href="about.html" className="nav-item nav-link">About</a>
                        <Link to='/course' className="nav-item nav-link">Courses</Link>
                        <div className="nav-item dropdown">
                            <a href="#" className="nav-link dropdown-toggle" data-bs-toggle="dropdown">Pages</a>
                            <div className="dropdown-menu fade-down m-0">
                                <a href="team.html" className="dropdown-item">Our Team</a>
                                <a href="testimonial.html" className="dropdown-item">Testimonial</a>
                                <a href="404.html" className="dropdown-item">404 Page</a>
                            </div>
                        </div>
                        <a href="contact.html" className="nav-item nav-link">Contact</a>
                    </div>
                </div>
            </nav>



            <form className="form">
                <p className="form-title">Sign in to your account</p>
                <div className="input-container">
                    <input value={email} onChange={handleEmail} type="email" placeholder="Enter email" />
                    <span>
                    </span>
                </div>
                <div className="input-container">
                    <input value={password} onChange={handlePassword} type="password" placeholder="Enter password" />
                </div>
                <button onClick={handleApi} type="submit" className="submit">
                    Sign in
                </button>
                <p className="signup-link">
                    No account?
                    <a href>Sign up</a>
                </p>
            </form>
        </div>
    )
}
