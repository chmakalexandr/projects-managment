import React, { Component } from 'react';
import axios from 'axios';
import withAuth from '../services/withAuth';

class Register extends Component {
  constructor(props){
    super(props);
    this.handleChange = this.handleChange.bind(this);
    this.handleFormSubmit = this.handleFormSubmit.bind(this);
    this.state={
      first_name:'',
      last_name:'',
      email:'',
      password:'',
      comfirm_password:'',
      info_message:''
    }
  }
  componentWillReceiveProps(nextProps){
    console.log("nextProps",nextProps);
  }

  handleFormSubmit(e){
    e.preventDefault();
    var apiBaseUrl = "http://localhost:61318/api/";
    // console.log("values in register handler",role);
    var self = this;
    //To be done:check for empty values before hitting submit
    if(this.state.first_name.length>0 && this.state.last_name.length>0 && this.state.email.length>0 && this.state.password.length>0 && this.state.password===this.state.confirm_password){
      var user={
        FirstName: this.state.first_name,
        LastName: this.state.last_name,
        Email: this.state.email,
        Password: this.state.password,
      };
      this.fetch(apiBaseUrl+'/registration', {
        method: 'POST',
        body: JSON.stringify(user)})
      .then(function (response) {
        console.log(response);
        if(response.status === 200){
          console.log("User created successfull");
          this.setState(
            {
                info_message:"User created successfull"
            }
          )
        }
        else {
         console.log("some error ocurred",response.data.code);
         this.setState(
          {
              info_message: response.data.code
          }
        )
        }
      })
      .catch(function (error) {
       console.log(error);
      });
    } else {
      this.setState(
      {
        info_message: "Input field value is missing"
      })
    }

  }

  handleChange(e){
    this.setState(
        {
            [e.target.name]: e.target.value
        }
    )
  }

  
  render() {
    return (
      <div className="center">
        <div className="card">
          <h1>Create user</h1>
          <form>
              <input
                className="form-item"
                placeholder="First name..."
                name="first_name"
                type="text"
                onChange={this.handleChange}
              />
              <input
                className="form-item"
                placeholder="Last name..."
                name="last_name"
                type="text"
                onChange={this.handleChange}
              />
              <input
                className="form-item"
                placeholder="Email..."
                name="email"
                type="text"
                onChange={this.handleChange}
              />
              <input
                className="form-item"
                placeholder="Password..."
                name="password"
                type="text"
                onChange={this.handleChange}
              />
              <input
                className="form-item"
                placeholder="Comfirm Password..."
                name="comfirm_password"
                type="text"
                onChange={this.handleChange}
              />
          
            <br/>
            <input
                className="form-submit"
                value="SUBMIT"
                type="submit"
                onClick={(event) => this.handleFormSubmit(event)}
            />
            </form>
        </div>
        <div>{this.info_message}</div>
      </div>
    );
  }
}

const style = {
  margin: 15,
};

export default withAuth(Register);
