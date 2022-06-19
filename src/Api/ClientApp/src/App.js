import React from 'react';
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import PrivateRoute from './config/PrivateRoute';
import Home from './components/Home/Home';
import Login from './components/Auth/Login';
import Register from './components/Auth/Register';

import './custom.css'

const App = () => {
  return (
    <Router>
        <Switch>
          <Route exact path='/login' component={Login} />
          <Route exact path='/register' component={Register}/>
          <PrivateRoute exact path='/' component={Home} />
        </Switch>
    </Router>
  );
}

export default App;
