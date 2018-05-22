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
      solver: "",
    };
  }

  handleChange(event) {
    console.log("Handle Change (App): " + event.target.value);
    console.log(event.target.value);
    this.setState({
      solver: event.target.value,
    })
  }

  componentDidUpdate(prevProps, prevState) {
    console.log("OH YEAH");
    //this.setState(this.state);
  }

  render() {
    console.log("Render App : " + this.state.solver);
    return (
      <div>
        <TicketsNavbar screenName="Solver Edition" />

        <div className="container">

          <form>
            <UserSelector userType="Solver" onChange={this.handleChange} value={this.state.solver} />
          </form>


          <Grid>
            <Row className="show-grid">
              <Col md={6}>
                <h2>My Current Tickets</h2>
                <AssignedTickets useremail={this.state.solver} />
              </Col>
              <Col md={6}>
                <h2>Unassigned Tickets</h2>
                <UnassignedTickets useremail={this.state.solver} />
              </Col>
            </Row>
          </Grid>
        </div>
      </div>
    );
  }
}