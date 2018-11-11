import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import './index.css';
import { BrowserRouter, Route } from 'react-router-dom';
import Login from './components/Login'



ReactDOM.render(
  <BrowserRouter>
  <div>
      <Route exact path="/" component={App} />
      <Route exact path="/login" component={Login} />
  </div>
 </BrowserRouter>
  
  ,document.getElementById('root')
);
