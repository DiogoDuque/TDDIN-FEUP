import React, { Component } from 'react';
import axios from 'axios';
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
    this.updateTickets = this.updateTickets.bind(this);
    this.updateAssignedTickets = this.updateAssignedTickets.bind(this);
    this.updateUnassignedTickets = this.updateUnassignedTickets.bind(this);
    this.state = {
      solver: "",
      page: "VisualizeTickets",
      isLoadingUnassigned: true,
      isLoadingAssigned: true,
    };
  }

  componentDidMount() {
    this.updateTickets();
  }

  handleChange(event) {
    this.setState({
      solver: event.target.value,
      page: this.state.page
    }, this.updateTickets(event.target.value))
  }

  changePage(key) {
    if (key === this.state.page)
      return;

    this.setState({
      solver: this.state.solver,
      page: key,
    });
  }

  updateUnassignedTickets() { // Unassigned
    axios.get('http://localhost:8000/GetUnassignedTickets')
      .then(response => {
        let unassignedTickets = response.data;
        this.setState({
          unassignedTickets,
          isLoadingUnassigned: false,
        });
      });
  }

  updateAssignedTickets(useremail) {
    console.log("Update Tickets (Assigned): " + useremail);
    axios.get(`http://localhost:8000/GetTicketsAndQuestions?solveremail=${useremail}`)
      .then(response => {
        console.log({title:"Assigned",response});
        let assignedTickets = response.data;
        this.setState({
          assignedTickets,
          isLoadingAssigned: false,
        });
      });
  }

  updateTickets(solver) {
    this.updateUnassignedTickets();
    this.updateAssignedTickets(solver? solver: this.state.solver);
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
                  <AssignedTickets useremail={this.state.solver} page={this.state.page} tickets={this.state.assignedTickets} updateTickets={() => this.updateTickets()} isLoading={this.state.isLoadingAssigned} />
                </Col>
                <Col md={6}>
                  <h2>Unassigned Tickets</h2>
                  <UnassignedTickets useremail={this.state.solver} tickets={this.state.unassignedTickets} updateTickets={() => this.updateTickets()} isLoading={this.state.isLoadingUnassigned} />
                </Col>
              </Row>
            </Grid>
          </div>
        }
        {this.state.page === 'AskDepartment' &&
          <AskDepartment tickets={this.state.assignedTickets} handleChange={this.handleChange} solver={this.state.solver} page={this.state.page} updateTickets={this.updateTickets} />}
      </div>
    );
  }
}