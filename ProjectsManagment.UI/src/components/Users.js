import React, { Component } from "react";
import MuiThemeProvider from "material-ui/styles/MuiThemeProvider";
import injectTapEventPlugin from "react-tap-event-plugin";
import orderBy from "lodash/orderBy";
import Can from "../services/Can";


import "../App.css";
import Form from "./Form";
import Table from "./Table";
import withAuth from '../services/withAuth';
import * as api from '../services/api';

//injectTapEventPlugin();

const invertDirection = {
  asc: "desc",
  desc: "asc"
};

class Users extends Component {

    constructor(props) {
        super(props);
        this.state = {
            data:[],
            editIdx: -1,
            columnToSort: "",
            sortDirection: "desc",
            showForm : false
        }
    
        this.componentDidMount = this.componentDidMount.bind(this);
        this.handleShow = this.handleShow.bind(this);
        
      }
 

  componentDidMount () {
   
    console.log("response");
            
    api.get("http://localhost:61318/api/Account/users")
      .then(response => {
        console.log(response);
        this.setState({data :  response});
      });
      
  }

  handleRemove = i => {
    const conf = window.confirm(`Are you sure?`);
    if (conf){
      this.setState(state => ({
        data: state.data.filter((row, j) => j !== i)
      }));
    }
    
  };

  startEditing = i => {
    this.setState({ editIdx: i });
  };

  stopEditing = () => {
    this.setState({ editIdx: -1 });
  };

  handleSave = (i, x) => {
    this.setState(state => ({
      data: state.data.map((row, j) => (j === i ? x : row))
    }));
    this.stopEditing();
  };

  handleSort = columnName => {
    this.setState(state => ({
      columnToSort: columnName,
      sortDirection:
        state.columnToSort === columnName
          ? invertDirection[state.sortDirection]
          : "asc"
    }));
  };

  handleShow = ()=>{
    
    this.setState({ showForm: true });
  }

  render() {
    
    
    return (
      <MuiThemeProvider>
        <div className="App">
        
          <Table
            handleSort={this.handleSort}
            handleRemove={this.handleRemove}
            startEditing={this.startEditing}
            editIdx={this.state.editIdx}
            stopEditing={this.stopEditing}
            handleSave={this.handleSave}
            columnToSort={this.state.columnToSort}
            sortDirection={this.state.sortDirection}
            data={orderBy(
              this.state.data,
              this.state.columnToSort,
              this.state.sortDirection
            )}
            header={[
              {
                name: "First name",
                prop: "FirstName"
              },
              {
                name: "Last name",
                prop: "LastName"
              },
              {
                name: "Email",
                prop: "Email"
              },
              {
                name: "Email Confirmed",
                prop: "EmailConfirmed"
              }
            ]}
          />

          <div>
              <Can
                    role={localStorage.getItem('role')}
                    perform="users:create"
                    yes={() => (
                      <button className="btn btn-success" onClick={this.handleShow}>
                        Create User
                      </button>
                    )}
               />
          </div>

          <Form
            showForm={this.state.showForm}
            onSubmit={submission =>
            this.setState({
              data: [...this.state.data, submission],
              
            })
            }
         />;
                    
          
        </div>
      </MuiThemeProvider>
    );
  }
}

export default withAuth(Users);