import React, {Component} from "react";
import withAuth from '../services/withAuth';
import Can from "../services/Can";
import * as api from '../services/api';


class UsersList extends Component {

    constructor(props){
        super(props);
        this.state = {
            loading: true,
            users:[]
        }
              
    }

    

    componentDidMount(){
        console.log("response");
            
        api.get("http://localhost:61318/api/Account/users")
          .then(response => {
            console.log(response);
            this.setState({users :  response, loading: false});
          });
    }

    render() {
        
        if (this.state.loading) {
            return <div>loading...</div>;
          }
      
        if (!this.state.users) {
           return <div>didn't get a person</div>;
        }
        console.log('users'+this.state.users);
        return (
            
            <div>
                <h2>Users List</h2>
                <table className="table">
                <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">FirstName</th>
                    <th scope="col">LastName</th>
                    <th scope="col">Email</th>
                    <th scope="col">Actions</th>
                </tr>
                </thead>
                <tbody>
                {this.state.users.map((user, index) => (
                    <tr key={user.Id}>
                    <th scope="row">{index + 1}</th>
                    <td>{user.FirstName}</td>
                    <td>{user.LastName}</td>
                    <td>{user.Email}</td>
                    <td>
                        <Can
                        role={localStorage.getItem('role')}
                        perform="users:edit"
                        data={{
                            userId: user.id,
                            
                        }}
                        yes={() => (
                            <button className="btn btn-sm btn-default">
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