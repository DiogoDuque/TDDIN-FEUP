import React, { Component } from 'react';
import { Navbar, Nav, NavItem } from 'react-bootstrap';

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
              <Nav onSelect={(eventKey) => this.props.changePage(eventKey)}>
                <NavItem eventKey={'Register'} href="#">Register</NavItem>
                <NavItem eventKey={'AskQuestion'} href="#">Create Ticket</NavItem>
              </Nav>
          </Navbar.Collapse>
        )}
      </Navbar>
    );
  }
}