import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Login from './components/Login';

import './custom.css'


const App = () => {
  return (
    <Layout>
      <Route exact path='/' component={Home} />
      <Route exact path='/login' component={Login} />
    </Layout>
  );
}

export default App;
