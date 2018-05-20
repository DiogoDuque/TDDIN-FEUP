import React, { Component } from 'react';
import axios from 'axios';

export default class ListUserOptions extends Component {
    constructor(props) {
        super(props);
        this.getUsers = this.getUsers.bind(this);
        
        this.state = {
            userType : this.props.userType,
            usersList : [],
        };
    }

    getUsers(userType) {
        console.log(userType);
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

    render()
    {
        var defaultOption=<option value="">Select your email...</option>;

        if(this.state.usersList == undefined || this.state.usersList.length == 0) {
            return [defaultOption];
        } else {
            var userOptions = this.state.usersList.map(
                function(user) {
                    return <option value={user.email}>{user.email}</option>;
            });
            
            return [defaultOption].concat(userOptions);
        }
    }
}