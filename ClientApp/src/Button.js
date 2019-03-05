import React, { Component } from 'react';
import PropTypes from 'prop-types';
import Collapse from 'react-collapse';

class Button extends Component {

    state = {
        open: false
    };
    collapse = () => {
        this.setState({ open: !this.state.open });
    };

    render (){
        return(
            <div>
                <button className="btn" onClick={this.collapse}>{this.props.title}</button>
                <Collapse isOpened={this.state.open}>
                    <iframe src={this.props.link} width="300" height="380" frameBorder="0" allowTransparency="true" allow="encrypted-media" title="noize"></iframe>
                </Collapse>
            </div>
        );
    }
}

Button.propTypes = {
    title: PropTypes.string,
    link: PropTypes.string
};

export default Button;