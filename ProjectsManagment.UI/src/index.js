import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import './index.css';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import Login from './components/Login';
import Register from './components/Register';
import UsersList from './components/UsersList';
import Users from './components/Users';
 
ReactDOM.render(
  <Router>
      <div>
          <Route exact path="/" component={App} />
          <Route exact path="/login" component={Login} />
          <Route exact path="/registration" component={Register} />
          <Route exact path="/users" component={Users} />
      </div>
  </Router>
  , document.getElementById('root')
);