import React, { Component } from 'react';
import { Grid, Col, Row, InputGroup, FormControl, Button } from 'react-bootstrap';
import TicketsNavbar from '../globalComponents/TicketsNavbar';
import AssignedTickets from './AssignedTicketsList';
import UnassignedTickets from './UnassignedTicketsList';
import UserSelector from '../globalComponents/UserSelector';
import SolverNavbar from './SolverNavbar';
import AskDepartment from './AskDepartmentScreen';

export default class App extends Component {
  constructor(props) {
    super(props);
    this.handleChange = this.handleChange.bind(this);
    this.changePage = this.changePage.bind(this);
    this.state = {
      solver: "",
      page: "VisualizeTickets",
    };
  }

  handleChange(event) {
    console.log("Handle Change (App): " + event.target.value);
    console.log(event.target.value);
    this.setState({
      solver: event.target.value,
      page: this.state.page
    })
  }

  componentDidUpdate(prevProps, prevState) {
  }

  changePage(key) {
    if (key === this.state.page)
      return;

    this.setState({
      solver: this.state.solver,
      page: key,
    });
  }

  render() {
    console.log("Render App : " + this.state.solver);
    return (
      <div>
        <SolverNavbar changePage={this.changePage} />

        {this.state.page === 'VisualizeTickets' &&
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
        }
        {this.state.page === 'AskDepartment' &&
        <AskDepartment handleChange={this.handleChange} solver={this.state.solver}/>}
      </div>
    );
  }
}