import React from "react";
import TextField from "material-ui/TextField";
import RaisedButton from "material-ui/RaisedButton";
import CheckIcon from "material-ui/svg-icons/navigation/check";
import CancelIcon from "material-ui/svg-icons/navigation/cancel";
import { TableRow, TableRowColumn } from "material-ui/Table";

export default class Form extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      values: {
        ...props.x
      },
      errors: {
        firstName: "",
        lastName: "",
        email: "",
        password: "",
        username: ""
      }
    };
  }

  change = e => {
    const { name, value } = e.target;
    this.setState(state => ({
      values: {
        ...state.values,
        [name]: value
      }
    }));
  };

  validate = () => {
    let isError = false;
    const errors = {
      firstName: "",
      lastName: "",
      username: "",
      email: "",
      password: ""
    };

    const { LastName,FirstName, Email } = this.state.values;

    if (FirstName.length < 2) {
        isError = true;
        errors.firstNameError = "firstName can not be blank ";
    }
    
    if (LastName.length < 2) {
        isError = true;
        errors.lastNameError = "lastName can not be blank ";
    }


    if (Email.indexOf("@") === -1) {
      isError = true;
      errors.email = "Requires valid email";
    }

    this.setState({
      errors
    });

    return isError;
  };

  onSubmit = e => {
    e.preventDefault();
    const err = this.validate();
    if (!err) {
      this.props.handleSave(this.props.i, this.state.values);
    }
  };

  render() {
    const { header, x, i } = this.props;
    return [
      header.map((y, k) => (
        <TableRowColumn key={`trc-${k}`}>
          <TextField
            name={y.prop}
            onChange={this.change}
            value={this.state.values[y.prop]}
            errorText={this.state.errors[y.prop]}
          />
        </TableRowColumn>
      )),
      <TableRowColumn key="icon-row-column">
        <CheckIcon onClick={this.onSubmit} />
        <CancelIcon onClick={this.props.stopEditing} />
      </TableRowColumn>
    ];
  }
}