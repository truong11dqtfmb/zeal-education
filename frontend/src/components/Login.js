import React from 'react'
import { Link } from 'react-router-dom'


export default function
    Login() {
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
                        <Link to='/course' className="nav-item nav-link">Courses</Link>
                        <Link to='/cart' className="nav-item nav-link">Cart</Link>
                    </div>
                </div>
            </nav>



            <form className="form">
                <p className="form-title">Sign in to your account</p>
                <div className="input-container">
                    <input type="email" placeholder="Enter email" />
                    <span>
                    </span>
                </div>
                <div className="input-container">
                    <input type="password" placeholder="Enter password" />
                </div>
                <button type="submit" className="submit">
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
