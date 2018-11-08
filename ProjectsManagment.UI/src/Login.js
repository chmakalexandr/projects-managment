import React, { Component } from 'react';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import AppBar from 'material-ui/AppBar';
import RaisedButton from 'material-ui/RaisedButton';
import TextField from 'material-ui/TextField';
import DropDownMenu from 'material-ui/DropDownMenu';
import MenuItem from 'material-ui/MenuItem';
import axios from 'axios';

var apiBaseUrl = "http://localhost:61318/api/Account/";

class Login extends Component {
  constructor(props){
    super(props);
    
    this.state={
      username:'',
      password:''      
    }
  }

  componentWillMount(){
  // console.log("willmount prop values",this.props);
      console.log("componentWillMount");
      var localloginComponent=[];
      localloginComponent.push(
        <MuiThemeProvider>
        <div>
           <TextField
             hintText="Enter your Email"
             floatingLabelText="Login"
             onChange = {(event,newValue) => this.setState({username:newValue})}
             />
           <br/>
             <TextField
               type="password"
               hintText="Enter your Password"
               floatingLabelText="Password"
               onChange = {(event,newValue) => this.setState({password:newValue})}
               />
             <br/>
             <RaisedButton label="Submit" primary={true} style={style} onClick={(event) => this.handleClick(event)}/>
         </div>
         </MuiThemeProvider>
      )
      this.setState({loginComponent:localloginComponent})
  }

  handleClick(event){
    //var apiBaseUrl = "http://localhost:4000/api/Account/";
    var self = this;
    ////var payload={
    //  "email":this.state.username,
    //  "password":this.state.password,
    //}

    let payload = JSON.stringify({
      Email: this.state.username,
      Password: this.state.password
      
    })
    let axiosConfig = {
      headers: {
          'accept': 'application/json',
          "Access-Control-Allow-Credentials" : "true",
          'Content-Type': 'application/json' ,
          "Access-Control-Allow-Origin": "http://localhost:61318/api/Account/login",
      }
    };
    axios.post(apiBaseUrl+'login', payload, axiosConfig)
    .then(function (response) {
        console.log(response);
        if(response.data.code == 200){
            console.log("Login successfull");
            alert("Login successfull")
        }
        else if(response.data.code == 204){
            console.log("Username password do not match");
            alert("username password do not match")
        }
        else{
            console.log("Username does not exists");
            alert("Username does not exist");
        }
    })
    .catch(function (error) {
        console.log(error);
        
    });
    }

  
  render() {
    return (
      <div>
        <MuiThemeProvider>
          <div>
          <AppBar
             title="Login"
           />
           <TextField
             hintText="Enter your Email"
             floatingLabelText="Login"
             onChange = {(event,newValue) => this.setState({username:newValue})}
             />
           <br/>
             <TextField
               type="password"
               hintText="Enter your Password"
               floatingLabelText="Password"
               onChange = {(event,newValue) => this.setState({password:newValue})}
               />
             <br/>
             <RaisedButton label="Submit" primary={true} style={style} onClick={(event) => this.handleClick(event)}/>
         </div>
         </MuiThemeProvider>
      </div>
    );
  }
}


const style = {
  margin: 15,
};

export default Login;
