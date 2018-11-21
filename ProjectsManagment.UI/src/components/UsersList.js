import React from "react";
import withAuth from '../services/withAuth';
import Can from "../services/Can";
import employees from "../employee";
import AuthService from "../services/AuthService";

const UsersList = () => (
    <div>
        <h2>Users List</h2>
        <table className="table">
          <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">Name{localStorage.getItem('user')}</th>
            <th scope="col">Actions</th>
          </tr>
          </thead>
          <tbody>
          {employees.map((employee, index) => (
            <tr key={employee.id}>
              <th scope="row">{index + 1}</th>
              <td>{employee.name}</td>
              <td>
                <Can
                  role={localStorage.getItem('role')}
                  perform="users:edit"
                  data={{
                    userId: employee.id,
                    postOwnerId: employee.ownerId
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

export default withAuth(UsersList);