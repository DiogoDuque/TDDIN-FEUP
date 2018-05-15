import React, { Component } from 'react';
import { Grid, Col, Row } from 'react-bootstrap';
import AssignedTickets from './AssignedTicketsList';
import UnassignedTickets from './UnassignedTicketsList';

export default class SolverView extends Component {
  render() {
    return (
      <div className="container">
        <div className="header">
          <h1>Trouble Tickets</h1>
        </div>
        <Grid>
          <Row className="show-grid">
            <Col md={6}>
              <h2>My Current Tickets</h2>
              <AssignedTickets username="lel" />
            </Col>
            <Col md={6}>
              <h2>Unassigned Tickets</h2>
              <UnassignedTickets />
            </Col>
          </Row>
        </Grid>
      </div>
    );
  }
}