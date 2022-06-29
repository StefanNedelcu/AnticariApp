import React from 'react';
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import PrivateRoute from './config/PrivateRoute';
import Home from './components/Home/Home';
import Login from './components/Auth/Login';
import Register from './components/Auth/Register';
import EditProfile from './components/Profile/EditProfile';
import AddPosting from './components/Postings/AddPosting';
import Wishlist from './components/Wishlist/Wishlist';

import './custom.css'

const App = () => {
  return (
    <Router basename='/'>
      <Switch>
        <Route exact path='/login' component={Login} />
        <Route exact path='/register' component={Register} />
        <PrivateRoute exact path='/' component={Home} />
        <PrivateRoute exact path='/settings' component={EditProfile} />
        <PrivateRoute exact path='/add-posting' component={AddPosting} />
        <PrivateRoute exact path='/wishlist' component={Wishlist} />
      </Switch>
    </Router>
  );
}

export default App;
