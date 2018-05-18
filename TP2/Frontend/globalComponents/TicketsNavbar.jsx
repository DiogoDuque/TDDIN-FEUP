import React, { Component } from 'react';
import { Navbar } from 'react-bootstrap';

export default class AskQuestion extends Component {
  render() {
    return (
      <Navbar inverse>
        <Navbar.Header>
          <Navbar.Brand>
            <p>Tickets System</p>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        {this.props.screenName && (
          <Navbar.Collapse>
              <Navbar.Text href="#">{this.props.screenName}</Navbar.Text>
          </Navbar.Collapse>
        )}
      </Navbar>
    );
  }
}