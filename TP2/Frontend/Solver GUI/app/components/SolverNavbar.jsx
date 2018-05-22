import React, { Component } from 'react';
import { Navbar, Nav, NavItem } from 'react-bootstrap';

export default class SolverNavbar extends Component {
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
                <NavItem eventKey={'VisualizeTickets'} href="#">Visualize</NavItem>
                <NavItem eventKey={'AskDepartment'} href="#">Ask Department</NavItem>
              </Nav>
          </Navbar.Collapse>
      </Navbar>
    );
  }
}