import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import Button from './Button';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import justin from './images/rename.jpg';
import Axios from 'axios';
import PropTypes from 'prop-types';

const MainPanda = () => {
    return (
        <div className="container">
            <div className="jumbotron">
                <h1 className="text-center h1style">Engineer & Technologist</h1>
                <h2 className="text-center h2style" >
                    <em>Hi, I&apos;m Justin Leaming.</em>
                </h2 >
                <h3 className="text-center">
          Learn more about <Link to='/rapcat'>me...</Link>
                </h3>
                <div className="thumbnail">
                    <img src={justin} alt="something" style={{ flex: 1, height: 1200, width: 900 }} />
                </div>
            </div>
        </div>
    );
};

const EightyMusic = (props) => {
    EightyMusic.propTypes = {
        track: PropTypes.object
    };

    let track = props.track;

    return (
        <div className="text-center">
            <h3 className="text-center col-xs-pull-7" style={{ color: '#e65c00' }}>Check out what I&apos;m listening to on Spotify!</h3>
            <div className="col-xs-12 col-xs-offset-4">
                <h4 className='h4style'><i className='fa-music fa' /> <i className='fa-music fa' /> The tunes... <i className='fa-music fa' /> <i className='fa-music fa' /></h4>
                <ul className="">
                    <div>
                        <Button title={`${track.title} ${track.artist}`} link={track.uri} />
                    </div>
                </ul>
            </div>
        </div>
    );
};

class App extends Component {
    constructor() {
        super();
        this.state = {
            track: {}
        };
    }
    async componentDidMount () {
        var response = await Axios.get('http://localhost:5111/tracks', {headers: {'Access-Control-Allow-Origin': '*'}});
        this.setState({track : response.data});
    }
    render() {
        return (
            <div>
                <MainPanda />
                <EightyMusic track={this.state.track}/>
            </div>
        );
    }
}

export default App;