import React, { Component } from 'react';

import './App.css';
import LoginScreen from './Loginscreen';
// Needed for onTouchTap
// http://stackoverflow.com/a/34015469/988941



class App extends Component {
  constructor(props){
    super(props);
    this.state={
      loginPage:[]      
    }
  }
  componentWillMount(){
    var loginPage =[];
    loginPage.push(<LoginScreen appContext={this}/>);
    this.setState({
                  loginPage:loginPage
                    })
  }
  render() {
    return (
      <div className="App">
        {this.state.loginPage}
        
      </div>
    );
  }
}

export default App;
