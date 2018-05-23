import React, { Component } from 'react';
import { FormGroup, FormControl, ControlLabel } from 'react-bootstrap';
import axios from 'axios';


export default class UserSelector extends Component {
    constructor(props) {
        super(props);
        this.getUsers = this.getUsers.bind(this);
        
        this.state = {
            userType : this.props.userType,
            usersList : [],
        };
    }

    getUsers(userType) {
        console.log("getUsers (UserSelector): "+ userType);
        axios.get(`http://localhost:8000/GetUsers?type=${userType}`)
        .then(response => {
            this.setState({
                userType,
                usersList: response.data,
            });
        })
    }

    componentDidMount() {
        this.getUsers(this.state.userType);
    }

    render() {
        let id=0;
        return (
            <FormGroup>
                <ControlLabel>Author</ControlLabel>
                <FormControl value={this.props.value} onChange={this.props.onChange} componentClass="select" placeholder="Enter username" name="author">
                    <option value="">Select your email...</option>;
                    {this.state.usersList.map(
                         function(user) {
                             return <option key={id++} value={user.email}>{user.email}</option>;
                    })}
                </FormControl>
            </FormGroup>
        );
    }
}