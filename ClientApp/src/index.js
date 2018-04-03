import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import registerServiceWorker from './registerServiceWorker';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'font-awesome/css/font-awesome.min.css';
import { BrowserRouter as Router} from 'react-router-dom';
import routes from './router';

ReactDOM.render(<Router > 
    {routes}
</Router>, document.getElementById('root'));
registerServiceWorker();
