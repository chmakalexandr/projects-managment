import React from "react";
import TextField from "material-ui/TextField";
import RaisedButton from "material-ui/RaisedButton";

export default (showForm) => class Form extends React.Component{
  state = {
    visible: this.props.showForm,
    FirstName: "",
    firstNameError: "",
    LastName: "",
    lastNameError: "",
    Email: "",
    emailError: "",
    Password: "",
    passwordError: "",
    ConfirmPassword:"",
    confirmPasswordError:"",
    EmailConfirmed:""
  };

  change = e => {
    // this.props.onChange({ [e.target.name]: e.target.value });
    this.setState({
      [e.target.name]: e.target.value
    });
  };

  validate = () => {
    let isError = false;
    const errors = {
      firstNameError: "",
      lastNameError: "",
      emailError: "",
      passwordError: "",
      confirmPasswordError:""
    };

    if (this.state.FirstName.length < 2) {
        isError = true;
        errors.firstNameError = "firstName can not be empty ";
    }
    
    if (this.state.LastName.length < 2) {
        isError = true;
        errors.lastNameError = "lastName can not be empty ";
    }

    if (this.state.Password != this.state.ConfirmPassword) {
        isError = true;
        console.log("mutch");
        errors.passwordError = "passsword and confirm password must match";
        errors.confirmPasswordError = "passsword and confirm password must match";
    } 

    if (this.state.Email.indexOf("@") === -1) {
      isError = true;
      errors.emailError = "Requires valid email";
    }

    this.setState({
      ...this.state,
      ...errors
    });

    return isError;
  };

  onSubmit = e => {
    e.preventDefault();
    const err = this.validate();
    console.log(this.state);
    if (!err) {
      this.props.onSubmit(this.state);
      // clear form
      this.setState({
        FirstName: "",
        firstNameError: "",
        LastName: "",
        lastNameError: "",
        Email: "",
        emailError: "",
        Password: "",
        passwordError: "",
        ConfirmPassword:"",
        confirmPasswordError: "",
      });
    }
  };

  handleCancel=()=>{
    this.setState({visible:false});
  }

  render() {
    
    if (this.state.visible) {
      return (
        <form>
          <TextField
            name="FirstName"
            hintText="First name"
            floatingLabelText="First name"
            value={this.state.FirstName}
            onChange={e => this.change(e)}
            errorText={this.state.firstNameError}
            floatingLabelFixed
          />
          <br />
          <TextField
            name="LastName"
            hintText="Last Name"
            floatingLabelText="Last Name"
            value={this.state.LastName}
            onChange={e => this.change(e)}
            errorText={this.state.lastNameError}
            floatingLabelFixed
          />
          <br />
          
          <TextField
            name="Email"
            hintText="Email"
            floatingLabelText="Email"
            value={this.state.Email}
            onChange={e => this.change(e)}
            errorText={this.state.emailError}
            floatingLabelFixed
          />
          <br />
          <TextField
            name="Password"
            hintText="Password"
            floatingLabelText="Password"
            value={this.state.Password}
            onChange={e => this.change(e)}
            errorText={this.state.passwordError}
            type="password"
            floatingLabelFixed
          />
          <br />
          <TextField
            name="ConfirmPassword"
            hintText="Comfirm Password..."
            floatingLabelText="Comfirm Password"
            value={this.state.ConfirmPassword}
            onChange={e => this.change(e)}
            errorText={this.state.confirmPasswordError}
            type="password"
            floatingLabelFixed
          />
          <br />
          <RaisedButton label="Submit" onClick={e => this.onSubmit(e)} primary />
          <button className="btn btn-md btn-danger" onClick={e => this.handleCancel(e)}>Cancel</button>
        </form>
      );
    } else {
      return (<div></div>);
    }
  }
}