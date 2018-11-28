import React, { Component }  from "react";
import {Route, Link} from 'react-router-dom'
import withAuth from '../services/withAuth';
import Can from "../services/Can";
import employees from "../employee";
import AuthService from "../services/AuthService";
import * as api from '../services/api';
import Modal from './Modal';


class UsersList extends Component {
  constructor(props) {
    super(props);
    this.state = {
      users:[],
      editUser: null,
      showWindow: false
    }

    this.componentDidMount = this.componentDidMount.bind(this);
    
  }

  showModal = (user) => {
    console.log("show");
    this.setState({ editUser :  user,
                    showWindow: true });
  };

  hideModal = () => {
    this.setState({ showWindow: false });
  };


  componentDidMount () {
    console.log("response");
            
    api.get("http://localhost:61318/api/Account/users")
      .then(response => {
        console.log(response);
        this.setState({users :  response});
      });
      
  }

  render() {

    var modal = '';
    if (this.state.editUser && this.state.showWindow){
      modal = <Modal show={this.state.showWindow} handleClose={this.hideModal}>
                <form>
                        <input
                            className="form-item"
                            name="FirstName"
                            type="text"
                            value={this.state.editUser.FirstName}
                        />
                        <input
                            className="form-item"
                            name="LastName"
                            type="text"
                            value={this.state.editUser.LastName}
                            
                        />
                        <input
                            className="form-submit"
                            value="SUBMIT"
                            type="submit"
                            onClick={(event) => this.handleFormSubmit(event)}
                        />
                    </form>
                
              </Modal>
    }

    return (
      <div>
        {modal}
        <h2>Users List</h2>
        <table className="table">
          <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">First Name</th>
            <th scope="col">Last Name</th>
            <th scope="col">Role</th>
            <th scope="col">Actions</th>
          </tr>
          </thead>
          <tbody>
          {this.state.users.map((employee, index) => (
            <tr key={employee.Id}>
              <th scope="row">{index + 1}</th>
              <td>{employee.FirstName}</td>
              <td>{employee.LastName}</td>
              <td><Link to={'/user/' + employee.Id}>{employee.Id}</Link></td>
              <td>
                <Can
                  role={localStorage.getItem('role')}
                  perform="users:edit"
                  data={{
                    userId: employee.Id,
                    
                  }}
                  yes={() => (
                    <button className="btn btn-sm btn-default" onClick={()=>this.showModal(employee)}>
                      Edit User
                    </button>
                  )}
                />
                <Can
                  role={localStorage.getItem('role')}
                  perform="users:delete"
                  yes={() => (
                    <button className="btn btn-sm btn-danger">
                      Delete User
                    </button>
                  )}
                />
              </td>
            </tr>
          ))}
          </tbody>
        </table>
        <div>
        <Can
                  role={localStorage.getItem('role')}
                  perform="users:create"
                  yes={() => (
                    <button className="btn btn-success">
                      Create User
                    </button>
                  )}
                />
        </div>
      </div>
    );
  }

    
}

export default withAuth(UsersList);