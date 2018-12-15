import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './App.css';
import _ from 'lodash';
import PropTypes from 'prop-types';


var possibleCombinationSum = function (arr, n) {
    if (arr.indexOf(n) >= 0) { return true; }
    if (arr[0] > n) { return false; }
    if (arr[arr.length - 1] > n) {
        arr.pop();
        return possibleCombinationSum(arr, n);
    }
    var listSize = arr.length, combinationsCount = (1 << listSize);
    for (var i = 1; i < combinationsCount; i++) {
        var combinationSum = 0;
        for (var j = 0; j < listSize; j++) {
            if (i & (1 << j)) { combinationSum += arr[j]; }
        }
        if (n === combinationSum) { return true; }
    }
    return false;
};

const Stars = (props) => {
    Stars.propTypes = {
        numberOfStars: PropTypes.any
    };
    return (
        <div className="col-5">
            {_.range(props.numberOfStars).map(i =>
                <i key={i} className="fa fa-star"></i>
            )}
        </div>
    );
};

const DoneFrame = (props) => {
    DoneFrame.propTypes = {
        doneStatus: PropTypes.any,
        resetGame: PropTypes.any
    };
    return (
        <div className="text-center">
            <h2>{props.doneStatus}</h2>
            <button className="btn btn-secondary" onClick={props.resetGame}>Play Again?</button>
        </div>
    );
};

const Button = (props) => {
    Button.propTypes = {
        answerIsCorrect: PropTypes.any,
        submitAnswer: PropTypes.any,
        selectedNumbers: PropTypes.any,
        addNumbers: PropTypes.any,
        redraws: PropTypes.any,
        redraw: PropTypes.any
    };
    let button;
    switch (props.answerIsCorrect) {
    case true:
        button = <button className="btn btn-success" onClick={props.submitAnswer}><i className="fa fa-check"></i></button>;
        break;
    case false:
        button = <button className="btn btn-danger"><i className="fa fa-times"></i></button>;
        break;
    default:
        button = <button className="btn" disabled={props.selectedNumbers.length === 0} onClick={props.addNumbers}>=</button>;
        break;
    }
    return (
        <div className="col-2 text-center">
            {button}
            <br /> <br />
            <buttton className="btn btn-warning btn-sm" onClick={props.redraw} disabled={props.redraws === 0}>
                <i className="fa fa-refresh"></i>
                <i>{props.redraws}</i>
            </buttton>
        </div>
    );
};

const Answer = (props) => {
    Answer.propTypes = {
        unSelectNumber: PropTypes.any
    };
    return (
        <div className="col-5">
            {props.selectedNumbers.map((number, i) =>
                <span key={i} onClick={() => props.unSelectNumber(number)}>{number}</span>
            )}
        </div>
    );
};

const Numbers = (props) => {
    Numbers.propTypes = {
        usedNumbers: PropTypes.any,
        selectedNumbers: PropTypes.any,
        selectNumber: PropTypes.any
    };
    const numberClassName = (number) => {
        if (props.usedNumbers.indexOf(number) >= 0) { return 'used'; }
        if (props.selectedNumbers.indexOf(number) >= 0) { return 'selected'; }
    };
    return (
        <div className="card text-center">
            <div>
                {Numbers.list.map((number, i) =>
                    <span key={i} className={numberClassName(number)} onClick={() => props.selectNumber(number)}>{number}</span>
                )}
            </div>
        </div>
    );
};

Numbers.list = _.range(1, 10);


class Game extends Component {

    static setInitialState = () => ({
        selectedNumbers: [],
        usedNumbers: [],
        numberOfStars: Game.randomNumber(),
        answerIsCorrect: null,
        redraws: 5,
        done: null
    });
    static randomNumber = () => 1 + Math.floor(Math.random() * 9);
    state = Game.setInitialState();
    resetGame = () => this.setState(Game.setInitialState());
    selectNumber = (clickedNumber) => {
        if (this.state.selectedNumbers.indexOf(clickedNumber) >= 0 || this.state.usedNumbers.indexOf(clickedNumber) >= 0) { return; }
        this.setState(prevState => ({
            answerIsCorrect: null,
            selectedNumbers: prevState.selectedNumbers.concat(clickedNumber)
        }));
    };
    unSelectNumber = (clickedNumber) => {
        this.setState(prevState => ({
            answerIsCorrect: null,
            selectedNumbers: prevState.selectedNumbers
                .filter(number => number !== clickedNumber)
        }));
    };
    addNumbers = () => {
        this.setState(prevState => ({
            answerIsCorrect: prevState.numberOfStars ===
                prevState.selectedNumbers.reduce((acc, n) => acc + n, 0)
        }));
    };
    redraw = () => {
        if (this.state.redraws === 0) { return; }
        this.setState(prevState => ({
            numberOfStars: Game.randomNumber(),
            answerIsCorrect: null,
            selectedNumbers: [],
            redraws: prevState.redraws - 1
        }), this.updateDoneStatus);
    };

    submitAnswer = () => {
        this.setState(prevState => ({
            usedNumbers: prevState.usedNumbers.concat(prevState.selectedNumbers),
            selectedNumbers: [],
            answerIsCorrect: null,
            numberOfStars: Game.randomNumber()
        }), this.updateDoneStatus);
    };

    possibleSolutions = ({ numberOfStars, usedNumbers }) => {
        const possibleNumbers = _.range(1, 10).filter(number =>
            usedNumbers.indexOf(number) === -1
        );

        return possibleCombinationSum(possibleNumbers, numberOfStars);
    };

    updateDoneStatus = () => {
        this.setState(prevState => {
            if (prevState.usedNumbers.length === 9) {
                return { done: 'Done. Nice!' };
            }
            if (prevState.redraws === 0 && !this.possibleSolutions(prevState))
                return { done: 'Game Over!' };
        });
    };
    render() {
        const { selectedNumbers, usedNumbers, numberOfStars, answerIsCorrect, redraws, done } = this.state;
        return (
            <div className="container">
                <Link to="/" style={{ float: 'right' }}><button style={{ backgroundColor: '#7B6282' }}>Home</button></Link>
                <h3>Play Nine</h3>
                <hr />
                <div className="row">
                    <Stars numberOfStars={numberOfStars} />
                    <Button selectedNumbers={selectedNumbers} addNumbers={this.addNumbers}
                        answerIsCorrect={answerIsCorrect} submitAnswer={this.submitAnswer}
                        redraw={this.redraw} redraws={redraws} />
                    <Answer selectedNumbers={selectedNumbers}
                        unSelectNumber={this.unSelectNumber} />
                </div>
                <br />
                {done ?
                    <DoneFrame doneStatus={done} resetGame={this.resetGame} /> :
                    <Numbers selectedNumbers={selectedNumbers}
                        usedNumbers={usedNumbers}
                        selectNumber={this.selectNumber} />
                }
            </div>
        );
    }
}

class PlayNine extends Component {
    render() {
        return (
            <div>
                <Game />
            </div>
        );
    }
}

export default PlayNine;
