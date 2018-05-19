import React, { Component } from 'react';
import { FormGroup, ControlLabel, FormControl, Button } from 'react-bootstrap';
import axios from 'axios';

export default class RegisterScreen extends Component {
    submitForm() {
        let elems = document.forms[0].elements;
        let obj = {
            username: elems[0].value,
            email: elems[1].value,
            type: elems[2].value,
        };

        axios({
            url:"http://localhost:8000/RegisterUser",
            method: 'post',
            data: obj,
            crossDomain: true,
        })
        .then(response => {
            if(response.data.RegisterUserResult) {
                alert('User registered successfully');
            } else {
                alert('Error authenticating user' + JSON.stringify(obj));
            }
            window.location.reload();
        });
    }

    render() {
        return (
            <div className="container">
                <div className="header">
                    <h1>Register</h1>
                </div>
                <div>
                    <form>
                        <FormGroup>
                            <ControlLabel>User Name</ControlLabel>
                            <FormControl type="text" placeholder="Enter username" name="user" />
                        </FormGroup>
                        <FormGroup>
                            <ControlLabel>Email</ControlLabel>
                            <FormControl type="email" placeholder="Enter email" name="email" />
                        </FormGroup>
                        <FormGroup>
                            <ControlLabel>Job Function</ControlLabel>
                            <FormControl componentClass="select">
                                <option value="">Select your job function...</option>
                                <option value="Worker">Worker</option>
                                <option value="Solver">Solver</option>
                            </FormControl>
                        </FormGroup>
                    </form>
                    <Button onClick={() => this.submitForm()}>Register</Button>
                </div>
            </div>
        )
    }
}