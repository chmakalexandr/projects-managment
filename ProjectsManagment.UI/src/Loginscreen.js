import React, { Component } from 'react';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import RaisedButton from 'material-ui/RaisedButton';

import Login from './Login';
//import Register from './Register';


class Loginscreen extends Component {
    constructor(props){
      super(props);
      this.state={
        username:'',
        password:'',
        loginscreen:[],
        loginmessage:'',
        isLogin:true
      }
    }
    componentWillMount(){
      var loginscreen=[];
      loginscreen.push(<Login parentContext={this} appContext={this.props.parentContext}/>);
      var loginmessage = "";
      this.setState({
                    loginscreen:loginscreen,
                    loginmessage:loginmessage
                      })
    }
    render() {
      return (
        <div className="loginscreen">
          {this.state.loginscreen}
          <div>
            {this.state.loginmessage}
            
          </div>
        </div>
      );
    }
  }
  
  const style = {
    margin: 15,
  };
  
  export default Loginscreen;