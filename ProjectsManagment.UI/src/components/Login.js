import React, { Component } from 'react';
import './css/Login.css';
import AuthService from '../services/AuthService';


class Login extends Component {
    constructor(){
        super();
        this.handleChange = this.handleChange.bind(this);
        this.handleFormSubmit = this.handleFormSubmit.bind(this);
        this.Auth = new AuthService();
        this.state={
            username:'',
            password:''
                
          }
    }
    render() {
        return (
            <div className="center">
                <div className="card">
                    <h1>Login</h1>
                    <form>
                        <input
                            className="form-item"
                            placeholder="Username goes here..."
                            name="username"
                            type="text"
                            onChange={this.handleChange}
                        />
                        <input
                            className="form-item"
                            placeholder="Password goes here..."
                            name="password"
                            type="password"
                            onChange={this.handleChange}
                        />
                        <input
                            className="form-submit"
                            value="SUBMIT"
                            type="submit"
                            onClick={(event) => this.handleFormSubmit(event)}
                        />
                    </form>
                </div>
            </div>
        );
    }

    componentWillMount(){
        if(this.Auth.loggedIn())
            this.props.history.replace('/');
    }
    

    handleChange(e){
        this.setState(
            {
                [e.target.name]: e.target.value
            }
        )
    }
    handleFormSubmit(e){
        e.preventDefault();
        console.log(this.state.username);
        console.log(this.state.password);
        this.Auth.login(this.state.username,this.state.password)
            .then(res =>{
               this.props.history.replace('/');
            })
            .catch(err =>{
                alert(err);
            })
    }
}

export default Login;
