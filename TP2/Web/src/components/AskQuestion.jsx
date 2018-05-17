import React, { Component } from 'react';
import { FormGroup, ControlLabel, FormControl, Button } from 'react-bootstrap';
import axios from 'axios';

export default class AskQuestion extends Component {
  submitForm() {
    let elems = document.forms[0].elements;
    let obj = {
      author: elems[0].value,
      title: elems[1].value,
      description: elems[2].value,
    };
    
    axios({
      url: "http://localhost:8000/AddTicket",
      method: 'put',
      data: obj,
      crossDomain: true,
    })
      .then(response => console.log(response));
  }

  render() {
    return (
      <div className="container">
        <h1>Ask a question!</h1>
        <form>
          <FormGroup>
            <ControlLabel>Author</ControlLabel>
            <FormControl type="text" placeholder="Enter username" name="author" />
          </FormGroup>
          <FormGroup>
            <ControlLabel>Title</ControlLabel>
            <FormControl type="text" placeholder="Enter title" name="title" />
          </FormGroup>
          <FormGroup>
            <ControlLabel>Description</ControlLabel>
            <FormControl componentClass="textarea" rows="10" placeholder="Enter description" name="description" />
          </FormGroup>
        </form>
        <Button onClick={() => this.submitForm()}>Submit</Button>
      </div>
    );
  }
}
