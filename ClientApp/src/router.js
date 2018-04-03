import React from 'react';
import { Route } from 'react-router-dom';

import App from "./App";
import CatApp from "./Cat";
import PlayNine from './Game';

export default (
    <div>
    <Route exact path="/" component={App} />
    <Route path="/rapcat" component={CatApp} />
    <Route path='/playnine' component={PlayNine} />
    </div>
);