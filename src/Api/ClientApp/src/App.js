import React from 'react';
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import PrivateRoute from './config/PrivateRoute';
import Home from './components/Home/Home';
import Login from './components/Auth/Login';
import Register from './components/Auth/Register';

import './custom.css'
import { AuthProvider } from './config/AuthContext';


const App = () => {
  return (
    <Router>
      <AuthProvider>
        <Switch>
          <Route exact path='/login' component={Login} />
          <Route exact path='/register' component={Register}/>
          <PrivateRoute exact path='/' component={Home} />
        </Switch>
      </AuthProvider>
    </Router>
  );
}

export default App;
