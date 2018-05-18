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
        <Navbar.Collapse>
          <Nav onSelect={(eventKey) => this.props.changePage(eventKey)}>
            <NavItem eventKey={'Register'} href="#">Register User</NavItem>
            <NavItem eventKey={'AskQuestion'} href="#">Ask Question(CLIENT)</NavItem>
            <NavItem eventKey={'SolverView'} href="#">Solver View(SOLVER)</NavItem>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}