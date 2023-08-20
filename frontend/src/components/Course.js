import React from 'react'
import { Link } from 'react-router-dom';
// import images
import course from '../img/course-1.jpg'
import course2 from '../img/course-2.jpg'
import course3 from '../img/course-3.jpg'
import about from '../img/about.jpg'
import carousel1 from '../img/carousel-1.jpg'
import carousel2 from '../img/carousel-2.jpg'
import cat1 from '../img/cat-1.jpg'
import cat2 from '../img/cat-2.jpg'
import cat3 from '../img/cat-3.jpg'
import cat4 from '../img/cat-4.jpg'
import team1 from '../img/team-1.jpg'
import team2 from '../img/team-2.jpg'
import team3 from '../img/team-3.jpg'
import team4 from '../img/team-4.jpg'
import testimonial1 from '../img/testimonial-1.jpg'
import testimonial2 from '../img/testimonial-2.jpg'
import testimonial3 from '../img/testimonial-3.jpg'
import testimonial4 from '../img/testimonial-4.jpg'




export default function 
() {
  return (
    <div>
        {/* <!-- Spinner Start --> */}
    {/* <div id="spinner" class="show bg-white position-fixed translate-middle w-100 vh-100 top-50 start-50 d-flex align-items-center justify-content-center">
        <div class="spinner-border text-primary" style={{width: '3rem',  height: '3rem'}} role="status">
            <span class="sr-only">Loading...</span>
        </div>
    </div> */}
    {/* <!-- Spinner End --> */}


    {/* <!-- Navbar Start --> */}
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
     {/* Navbar End  */}



    
        

    
    <div className="container-fluid bg-dark text-light footer pt-5 mt-5 wow fadeIn" data-wow-delay="0.1s">
        <div className="container py-5">
            <div className="row g-5">
                <div className="col-lg-3 col-md-6">
                    <h4 className="text-white mb-3">Quick Link</h4>
                    <a className="btn btn-link" href="">About Us</a>
                    <a className="btn btn-link" href="">Contact Us</a>
                    <a className="btn btn-link" href="">Privacy Policy</a>
                    <a className="btn btn-link" href="">Terms & Condition</a>
                    <a className="btn btn-link" href="">FAQs & Help</a>
                </div>
                <div className="col-lg-3 col-md-6">
                    <h4 className="text-white mb-3">Contact</h4>
                    <p className="mb-2"><i className="fa fa-map-marker-alt me-3"></i>123 Street, New York, USA</p>
                    <p className="mb-2"><i className="fa fa-phone-alt me-3"></i>+012 345 67890</p>
                    <p className="mb-2"><i className="fa fa-envelope me-3"></i>info@example.com</p>
                    <div className="d-flex pt-2">
                        <a className="btn btn-outline-light btn-social" href=""><i className="fab fa-twitter"></i></a>
                        <a className="btn btn-outline-light btn-social" href=""><i className="fab fa-facebook-f"></i></a>
                        <a className="btn btn-outline-light btn-social" href=""><i className="fab fa-youtube"></i></a>
                        <a className="btn btn-outline-light btn-social" href=""><i className="fab fa-linkedin-in"></i></a>
                    </div>
                </div>
                <div className="col-lg-3 col-md-6">
                    <h4 className="text-white mb-3">Gallery</h4>
                    <div className="row g-2 pt-2">
                        <div className="col-4">
                            <img class="img-fluid bg-light p-1" src={course} alt=""/>
                        </div>
                        <div className="col-4">
                            <img class="img-fluid bg-light p-1" src={course2} alt=""/>
                        </div>
                        <div className="col-4">
                            <img class="img-fluid bg-light p-1" src={course3} alt=""/>
                        </div>
                        <div className="col-4">
                            <img class="img-fluid bg-light p-1" src={course2} alt=""/>
                        </div>
                        <div className="col-4">
                            <img class="img-fluid bg-light p-1" src={course3} alt=""/>
                        </div>
                        <div className="col-4">
                            <img class="img-fluid bg-light p-1" src={course} alt=""/>
                        </div>
                    </div>
                </div>
                <div className="col-lg-3 col-md-6">
                    <h4 className="text-white mb-3">Newsletter</h4>
                    <p>Dolor amet sit justo amet elitr clita ipsum elitr est.</p>
                    <div className="position-relative mx-auto" style={{maxWidth: '400px'}}>
                        <input className="form-control border-0 w-100 py-3 ps-4 pe-5" type="text" placeholder="Your email"/>
                        <button type="button" className="btn btn-primary py-2 position-absolute top-0 end-0 mt-2 me-2">SignUp</button>
                    </div>
                </div>
            </div>
        </div>
        <div className="container">
            <div className="copyright">
                <div className="row">
                    <div className="col-md-6 text-center text-md-start mb-3 mb-md-0">
                        &copy; <a className="border-bottom" href="#">Your Site Name</a>, All Right Reserved.

                        
                        Designed By <a class="border-bottom" href="https://htmlcodex.com">HTML Codex</a>
                    </div>
                    <div className="col-md-6 text-center text-md-end">
                        <div className="footer-menu">
                            <a href="">Home</a>
                            <a href="">Cookies</a>
                            <a href="">Help</a>
                            <a href="">FQAs</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    


    
    <a href="#" className="btn btn-lg btn-primary btn-lg-square back-to-top"><i className="bi bi-arrow-up"></i></a>

    </div>

    
  )
}

