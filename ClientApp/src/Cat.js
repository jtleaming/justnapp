import React, { Component } from 'react';
import {Link} from 'react-router-dom';
import './App.css';
import axios from 'axios';



class CatApp extends Component{

    constructor() {
        super()
        this.state = {
            name: '',
            email:'',
            phoneNumber: '',
            message: ''
        };
        this.handleClick = this.handleClick.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
    }; 

    handleClick(event){
        axios.post('http://10.0.75.1:5002/api/sendmessage', {
            name: this.state.name,
            message: this.state.message
        }, { headers: { "Access-Control-Allow-Origin": "*", "Access-Control-Allow-Headers": " Origin, X-Requested-With, Content-Type, Accept" } })
        .then(function (response) {
            console.log(response);
        })
        .catch(function (error) {
            window.prompt(error);
        });
    };

    handleInputChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
    }

    render(){
        return(
        <div>
            <nav id="banner" className="navbar navbar-default navbar-static-top" >
                <div className="container">
                    <Link to='/playnine' ><img className="smaller-image" src='http://www.ravensingstheblues.com/wp-content/uploads/2016/10/MixtapeIcon.jpg' alt="something"/></Link>
                <div>
                    <Link to="/"><button style={{ backgroundColor:'#7B6282' }}>Home</button></Link>
                        <button style={{ backgroundColor:'#548CB2' }}>About</button>
                        <button style={{ backgroundColor:'#509938' }}>Portfolio</button>
                        <button style={{ backgroundColor:'#EBC647' }}>Contact</button>
                </div>
                </div>
            </nav>
            <br/>
            <a id="top" rel="nofollow" name="home">
                <main>
                    <header>
                        <div className="intro-text">
                            <p style={{align: 'right', width: '600px', fontsize: '20px'}}>We are the murderous pair that went to jail and murdered the murderers there, that went to hell and discovered the devil delivers some hurt and dispair, used to have powder to push, now I smoke poounds of the kush, holy I'm burning the bush. </p>
                            <br />
                            <hr className="star-bright"></hr>
                            <p>The strength of street knowledge</p>
                        </div>
                        <img src="https://tse4.mm.bing.net/th?id=OIP.HS-xXop6NIFJhZrYsyDxnAEsEs&pid=15.1" alt="doom"/>
                    </header>
                        <section id="portfolio">
                            <h2>Portfolio</h2>
                            <ul className="grid">
                                <li><div className="cat-photos" style={{ backgroundImage: `url("http://i1.ytimg.com/vi/G96DtYMpqcc/hqdefault.jpg")`}} alt="cat"/></li>
                                <li><div className="cat-photos" style={{ backgroundImage: `url("http://file.mobilmusic.ru/4c/27/72/681903-320.jpg")`}} alt="cat" /></li>
                                <li><div className="cat-photos" style={{ backgroundImage: `url("https://mediumlarge.files.wordpress.com/2014/05/cat-rap-8.jpg")`}} alt="cat"/></li>
                                <li><div className="cat-photos" style={{ backgroundImage: `url("https://s3.amazonaws.com/rapgenius/dj_cat.jpg")`}} alt="cat" /></li>
                            </ul>
                        </section>
                        <section id="contact">
                            <h2>Contact</h2>
                            <hr className="star-dark" />
                            <div>
                                <form id="contactForm" noValidate="">
                                    <div className="form-item">
                                        <label htmlFor="name">Name</label>
                                        <input name="name" placeholder="Name" required="" type="text" onChange={this.handleInputChange} value={this.state.name}/>
                                    </div>
                                    <div className="form-item">
                                        <label htmlFor="email">Email</label>
                                        <input name="email" placeholder="Email" required="" type="email" onChange={this.handleInputChange} value={this.state.email}/>
                                    </div>
                                    <div className="form-item">
                                        <label htmlFor="phone">Phone Number</label>
                                        <input name="phoneNumber" placeholder="Phone Number" required="" type="tel" onChange={this.handleInputChange} value={this.state.phoneNumber}/>
                                    </div>
                                    <div className="form-item">
                                        <label htmlFor="message">message</label>
                                        <textarea placeholder="What do you have to say" name="message" required="" id="message" cols="30" rows="10" value={this.state.message} onChange={this.handleInputChange}></textarea>
                                    </div>
                                    <br />
                                    <button onClick={this.handleClick}>Submit</button>
                                </form>
                                    <div>
                                        <p>
                                            We returned from the depths to the badland, with a gun and a knife in the waste band...
                                        </p>
                                        <p>
                                            ...went to war with devil and shaytan. He wore a bad toupee and a spray tan.
                                        </p>
                                        <p>
                                            So high now hoping that I land, on the thai stick moving through Thailand. On the radio heard the plane highjack. Government did that while they cooked crack...
                                        </p>
                                    </div>
                                </div>
        </section>
        </main>
        </a>
                    <footer>
                        <div id="footer-above">
                            <div>
                                <h3>The public enemy number one...</h3>
                                <p>Coffee <i className="fa fa-fw fa-coffee"></i> Music <i className="fa fa-fw fa-headphones"> </i> Stuff <i className="fa fa-fw fa-circle"> </i></p>
                            </div>
                            <div>
                                <h3>Find Me</h3>
                                <ul>
                                <li><a target='_blank' rel="noopener noreferrer" className="button social" href="https://www.facebook.com/justin.leaming"><i className="fa fa-fw fa-facebook"></i></a></li>
                                <li><a target='_blank' rel="noopener noreferrer" className="button social" href="https://www.instagram.com/justleaming/"><i className="fa fa-fw fa-instagram"></i></a></li>
                                <li><a target='_blank' rel="noopener noreferrer" className="button social" href="https://www.linkedin.com/in/justin-leaming-55698b106"><i className="fa fa-fw fa-linkedin"></i></a></li>
                                <li><a target='_blank' rel="noopener noreferrer" className="button social" href="https://twitter.com/justleaming"><i className="fa fa-fw fa-twitter"></i></a></li>
                                </ul>
                            </div>
                        </div>

                        <div id="footer-below">
                            <h5>Can't touch this...</h5>
                        </div>
                    </footer>
            </div>
        );
    }
}

export default CatApp;