import React, { Component } from 'react';
import AuthService from './AuthService';

export default function withAuth(AuthComponent) {

    const Auth = new AuthService('http://localhost:61318/api/Account/');

    return class AuthWrapped extends Component {
        constructor() {
            super();
            this.state = {
                user: null
            } 
        }

        componentWillMount() {
            if (!Auth.loggedIn()) {
                console.log("withAuth. not login");
                this.props.history.replace('/login')
            }
            else {
                try {
                    console.log("withAuth.  login suces");
                    //const profile = Auth.getProfile()
                    //console.log(profile);
                    //this.setState({
                    //    user: profile
                    //})
                }
                catch(err){
                    Auth.logout()
                    this.props.history.replace('/login')
                }
            }
        }

        render() {
            if (Auth.loggedIn()) {
                return (
                    <AuthComponent history={this.props.history} user={this.state.user} />
                )
            }
            else {
                return null
            }
        }
           
    }
}
