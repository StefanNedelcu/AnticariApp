import React from 'react';
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import PrivateRoute from './config/PrivateRoute';
import Layout from './components/Layout';
import Home from './components/Home';
import Login from './components/Login';
import Register from './components/Register';

import './custom.css'
import { AuthProvider } from './config/AuthContext';


const App = () => {
  return (
    <Router>
      <AuthProvider>
        <Layout>
          <Switch>
            <Route exact path='/login' component={Login} />
            <Route exact path='/register' component={Register}/>
            <PrivateRoute exact path='/' component={Home} />
          </Switch>
        </Layout>
      </AuthProvider>
    </Router>
  );
}

export default App;
