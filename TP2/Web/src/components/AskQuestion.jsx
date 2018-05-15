import React, { Component } from 'react';
import { FormGroup, ControlLabel, FormControl } from 'react-bootstrap';

export default class AskQuestion extends Component {
  render() {
    return (
      <div className="container">
        <h1>Ask a question!</h1>
        <form>
          <FormGroup bsSize="large">
            <ControlLabel>Title</ControlLabel>
            <FormControl type="text" label="Text" placeholder="Enter title" />
          </FormGroup>
          <FormGroup>
            <ControlLabel>Description</ControlLabel>
            <FormControl componentClass="textarea" rows="13" placeholder="Enter description" />
          </FormGroup>
        </form>
      </div>
    );
  }
}