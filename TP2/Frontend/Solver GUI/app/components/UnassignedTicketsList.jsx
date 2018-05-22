import React from 'react';
import axios from 'axios';
import Ticket from '../globalComponents/Ticket';
import { Button, ListGroup, ListGroupItem } from 'react-bootstrap';

export default class UnassignedTickets extends React.Component {
  constructor(props) {
    super(props);
    this.assignTicket = this.assignTicket.bind(this);
    this.updateTickets = this.updateTickets.bind(this);
    console.log("Unassigned Tickets constructor : " + this.props.useremail);
    this.state = {
      tickets: null,
      isLoading: true,
      useremail: this.props.useremail,
    };
  }

  componentDidUpdate(prevProps, prevState) {
    if(this.props.useremail != prevProps.useremail)
      this.updateTickets(this.props.useremail);
  }

  componentDidMount() {
    this.updateTickets(this.state.useremail);
  }

  updateTickets(useremail) {
    axios.get('http://localhost:8000/GetUnassignedTickets')
      .then(response => {
        console.log({title:"Unassigned",response});
        let tickets = response.data;
        this.setState({
          isLoading: false,
          tickets,
          useremail,
        });
      });
  }

  assignTicket(id) {
    let obj = {
      solveremail: this.state.useremail,
      ticketid: id
    }
    axios({
      url: 'http://localhost:8000/AssignSolverToTicket',
      method: 'put',
      data: obj,
      crossDomain: true
    })
    .then(response => {
      if(response.data.AssignSolverToTicketResult) {
        alert('You assigned yourself a *ticket*!');
      } else {
        alert('Error. Ticket could not be assigned.');
      }
      window.location.reload();
    })
  }

  render() {
    console.log("Render Unassigned Tickets :" + this.state.useremail);
    if (this.state.isLoading) {
      return (
        <p>Loading</p>
      );
    }

    if(this.state.tickets.length === 0 || this.state.useremail === "")
      return(
        <p>No unassigned tickets available!</p>
      );

    return (
      <div>
        {this.state.tickets.map(ticket => (
          <ListGroup>
            <ListGroupItem>
              <Ticket key={ticket.id} data={ticket} />
              <Button onClick={(e) => this.assignTicket(ticket.id, e)}>Assign me!</Button>
            </ListGroupItem>
          </ListGroup>
        ))}
      </div>
    );
  }
}