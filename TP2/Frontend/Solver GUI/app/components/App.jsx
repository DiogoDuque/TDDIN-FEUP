import React, { Component } from 'react';
import { Grid, Col, Row, InputGroup, FormControl, Button } from 'react-bootstrap';
import TicketsNavbar from '../globalComponents/TicketsNavbar';
import AssignedTickets from './AssignedTicketsList';
import UnassignedTickets from './UnassignedTicketsList';

export default class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      solver: "solver1",
      username: "solver1",
    };
  }

  render() {
    return (
      <div>
        <TicketsNavbar screenName="Solver Edition" />

        <div className="container">

          <InputGroup>
            <InputGroup.Addon>Username: </InputGroup.Addon>
            <FormControl type="text" value={this.state.username} onChange={(e) => this.setState({ username: e.target.value })} />
            <InputGroup.Button onClick={() => this.setState({ solver: this.state.username })}><Button>Update Solver Name</Button></InputGroup.Button>
          </InputGroup>

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