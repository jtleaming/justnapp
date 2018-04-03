import React, { Component } from 'react';
import {Link} from 'react-router-dom';
import Button from './Button';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';

const MainPanda = (props) =>{
  return (
          <div className="container">
            <div className="jumbotron">
              <h1 className="text-center h1style">Flood the Speakers with Heat Seekers</h1>
              <h2 className="text-center h2style" >
                <em>The illenist... Killen this...</em>
              </h2 >
              <h3 className="text-center">
                Take me to your <Link to='/rapcat'>leader</Link>
              </h3>
                  <div className="thumbnail">
                  <img src="http://www.dadsbigplan.com/images/uploads/2009/07/panda-rainbow-large.jpg" alt="something" />
                  <p className="caption text-center" style={{color: '#46b963'}}>"Panda bears don't care, break your neck though it's unfair..."</p>
                  </div>
            </div>
          </div>
  );
};

const EightyMusic = (props) =>{
  let songs = [{ title: "Paul's Boutique", link: "https://open.spotify.com/embed/track/2qq0RYYIuQxXcOxQKN0drC" }, { title: "It Takes a Nation of Millions", link: "https://open.spotify.com/embed/track/6jg8Y7gArYgZeXUBPMre0V" }, { title: "Straight Outta Compton", link: "https://open.spotify.com/embed/track/6KIKRz9eSTXdNsGUnomdtW" }];
  return(
    <div className="text-center">
    <h3 className="text-center col-xs-pull-7" style={{ color: '#e0e006' }}>Listen' to the 80's: it's vicious as rabies.</h3>
    <div className="col-xs-12 col-xs-offset-4">
      <h4 style={{ color: '#d47311' }}>Mmmmm, wrap music...</h4>
      <ul className="">
        <div>{
            songs.map((song,i)=>
            <Button title={song.title} link={song.link} key={i}/>
          )}
          
        </div>
      </ul>
      <h4>Click here for mad killa <a href="https://en.wikipedia.org/wiki/Giant_panda">pandas</a>.</h4>
    </div>
    </div>
  );
};

class App extends Component {
  render() {
    return (
            <div>
            <MainPanda />
            <EightyMusic />
            </div>
    );
  }
}

export default App;