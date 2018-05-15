import React from 'react';
import { ListGroup, ListGroupItem, Grid, Row, Col } from 'react-bootstrap';
import AssignedTickets from './AssignedTicketsList';
import UnassignedTickets from './UnassignedTicketsList';

class App extends React.Component {
  constructor() {
    super();
  }

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
              <AssignedTickets username="lel"/>
            </Col>
            <Col md={6}>
              <h2>Unassigned Tickets</h2>
              <UnassignedTickets/>
            </Col>
          </Row>
        </Grid>
      </div>
    );
  }
}

export default App;
