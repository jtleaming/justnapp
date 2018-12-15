import React, { Component } from 'react';
import {Link} from 'react-router-dom';
import './App.css';
import axios from 'axios';
import me from './images/image.jpg';



class CatApp extends Component{

    constructor() {
        super();
        this.state = {
            name: '',
            email:'',
            phoneNumber: '',
            message: ''
        };
        this.handleClick = this.handleClick.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
    } 

    handleClick(){
        axios.post('http://localhost:5002/api/sendmessage', {
            name: this.state.name,
            message: this.state.message
        }, { headers: { 'Access-Control-Allow-Origin': '*', 'Access-Control-Allow-Headers': ' Origin, X-Requested-With, Content-Type, Accept' } })
            .then(function () {
                // console.log(response.data);
            })
            .catch(function (error) {
                window.prompt(error);
            });
    }

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
                                <p style={{align: 'right', width: '600px', fontsize: '20px'}}>Hi there, I'm Justin. Technology enthusiest with a passion for software architecture and engineering. When I'm not behind a keyboard I'm cooking or doing something outside. I love great food and good wine.</p>
                                <br />
                                <hr className="star-bright"></hr>
                                <p>Also, a strong proponent of the robot uprising.</p>
                            </div>
                            <img src={me} alt="doom" className="doom"/>
                        </header>
                        <section id="portfolio">
                            <h2>Portfolio</h2>
                            <ul className="grid">
                                <li><div className="cat-photos" style={{ backgroundImage: 'url("http://i1.ytimg.com/vi/G96DtYMpqcc/hqdefault.jpg")'}} alt="cat"/></li>
                                <li><div className="cat-photos" style={{ backgroundImage: 'url("http://file.mobilmusic.ru/4c/27/72/681903-320.jpg")'}} alt="cat" /></li>
                                <li><div className="cat-photos" style={{ backgroundImage: 'url("https://mediumlarge.files.wordpress.com/2014/05/cat-rap-8.jpg")'}} alt="cat"/></li>
                                <li><div className="cat-photos" style={{ backgroundImage: 'url("https://s3.amazonaws.com/rapgenius/dj_cat.jpg")'}} alt="cat" /></li>
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
                                            Have some web or app development project you need coded?
                                    </p>
                                    <p style={{fontWeight:1000, fontSize:25}}>
                                            Look no further!
                                    </p>
                                    <p>
                                            I'm open for hire. Send me a message to get in touch. Or just send me a message to say 'what's up?'
                                    </p>
                                    <p>
                                            (Also, if you're a tattoo professional I trade my services for tattoos.)
                                    </p>
                                </div>
                            </div>
                        </section>
                    </main>
                </a>
                <footer>
                    <div id="footer-above">
                        <div>
                            <h3>Fueled by...</h3>
                            <div style={{padding:8}}>
                                <p>Coffee <i className="fa fa-fw fa-coffee"></i> Music <i className="fa fa-fw fa-headphones"> </i> Stuff <i className="fa fa-fw fa-circle"> </i></p>
                            </div>
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
                </footer>
            </div>
        );
    }
}

export default CatApp;