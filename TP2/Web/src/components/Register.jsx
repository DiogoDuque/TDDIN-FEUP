import React, { Component } from 'react';
import { FormGroup, ControlLabel, FormControl, Button } from 'react-bootstrap';

export default class Register extends Component {
    submitForm() {
        //TODO Register User
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
                                <option value="worker">Worker</option>
                                <option value="solver">Solver</option>
                            </FormControl>
                        </FormGroup>
                    </form>
                    <Button onClick={() => this.submitForm()}>Register</Button>
                </div>
            </div>
        )
    }
}