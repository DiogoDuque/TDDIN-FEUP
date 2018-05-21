import React, { Component } from 'react';
import { Grid, Col, Row, InputGroup, FormControl, Button } from 'react-bootstrap';
import TicketsNavbar from '../globalComponents/TicketsNavbar';
import AssignedTickets from './AssignedTicketsList';
import UnassignedTickets from './UnassignedTicketsList';
import UserSelector from '../globalComponents/UserSelector';

export default class App extends Component {
  constructor(props) {
    super(props);
    this.handleChange = this.handleChange.bind(this);
    this.state = {
      solver: "solver1",
      user: "solver1",
    };
  }

  handleChange(event) {
    this.setState({
      user: event.target.value,
    })
  }

  render() {
    return (
      <div>
        <TicketsNavbar screenName="Solver Edition" />

        <div className="container">

          <form>
            <UserSelector userType="Solver" onChange={this.handleChange} value={this.state.user} />
          </form>


          <Grid>
            <Row className="show-grid">
              <Col md={6}>
                <h2>My Current Tickets</h2>
                <AssignedTickets username={this.state.solver} />
              </Col>
              <Col md={6}>
                <h2>Unassigned Tickets</h2>
                <UnassignedTickets username={this.state.solver} />
              </Col>
            </Row>
          </Grid>
        </div>
      </div>
    );
  }
}