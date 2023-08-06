import React from 'react'
import { Link } from 'react-router-dom';

import cat1 from '../img/cat-1.jpg'
import cat2 from '../img/cat-2.jpg'
import cat3 from '../img/cat-3.jpg'
import cat4 from '../img/cat-4.jpg'

export default function 
() {
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
            <Link to="/login" className="btn btn-primary py-4 px-lg-5 d-none d-lg-block">Join Now<i class="fa fa-arrow-right ms-3"></i></Link>
        </div>
    </nav>

    <div class="container-fluid bg-primary py-5 mb-5 page-header">
        <div class="container py-5">
            <div class="row justify-content-center">
                <div class="col-lg-10 text-center">
                    <h1 class="display-3 text-white animated slideInDown">Courses</h1>
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb justify-content-center">
                            <li class="breadcrumb-item"><Link class="text-white" to="/">Home</Link></li>
                            <li class="breadcrumb-item"><a class="text-white" href="#">Pages</a></li>
                            <li class="breadcrumb-item text-white active" aria-current="page">Courses</li>
                        </ol>
                    </nav>
                </div>
            </div>
        </div>
    </div>


    <div className="container-xxl py-5 category">
        <div className="container">
            <div className="text-center wow fadeInUp" data-wow-delay="0.1s">
                <h6 className="section-title bg-white text-center text-primary px-3">Categories</h6>
                <h1 className="mb-5">Courses Categories</h1>
            </div>
            <div className="row g-3">
                <div className="col-lg-7 col-md-6">
                    <div className="row g-3">
                        <div className="col-lg-12 col-md-12 wow zoomIn" data-wow-delay="0.1s">
                            <a className="position-relative d-block overflow-hidden" href="">
                                <img className="img-fluid" src={cat1} alt=""/>
                                <div className="bg-white text-center position-absolute bottom-0 end-0 py-2 px-3" style={{margin: '1px'}}>
                                    <h5 className="m-0">Web Design</h5>
                                    <small className="text-primary">49 Courses</small>
                                </div>
                            </a>
                        </div>
                        <div className="col-lg-6 col-md-12 wow zoomIn" data-wow-delay="0.3s">
                            <a className="position-relative d-block overflow-hidden" href="">
                                <img className="img-fluid" src={cat2} alt=""/>
                                <div className="bg-white text-center position-absolute bottom-0 end-0 py-2 px-3" style={{margin: '1px'}}>
                                    <h5 className="m-0">Graphic Design</h5>
                                    <small className="text-primary">49 Courses</small>
                                </div>
                            </a>
                        </div>
                        <div className="col-lg-6 col-md-12 wow zoomIn" data-wow-delay="0.5s">
                            <a className="position-relative d-block overflow-hidden" href="">
                                <img className="img-fluid" src={cat3} alt=""/>
                                <div className="bg-white text-center position-absolute bottom-0 end-0 py-2 px-3" style={{margin: '1px'}}>
                                    <h5 className="m-0">Video Editing</h5>
                                    <small className="text-primary">49 Courses</small>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
                <div className="col-lg-5 col-md-6 wow zoomIn" data-wow-delay="0.7s" style={{minHeight: '350px'}}>
                    <a className="position-relative d-block h-100 overflow-hidden" href="">
                        <img className="img-fluid position-absolute w-100 h-100" src={cat4} alt="" style={{objectFit: 'cover'}}/>
                        <div className="bg-white text-center position-absolute bottom-0 end-0 py-2 px-3" style={{margin:  '1px'}}>
                            <h5 className="m-0">Online Marketing</h5>
                            <small className="text-primary">49 Courses</small>
                        </div>
                    </a>
                </div>
            </div>
        </div>
    </div>
    </div>
  )
}
