import React from 'react';
import axios from 'axios';
import Ticket from '../globalComponents/Ticket';
import { Button, ListGroup, ListGroupItem } from 'react-bootstrap';

export default class UnassignedTickets extends React.Component {
  constructor(props) {
    super(props);
    this.assignTicket = this.assignTicket.bind(this);
    this.state = {
      tickets: props.tickets,
    };
  }

  assignTicket(ticket) {
    let obj = {
      ticketid: ticket.id
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
      this.props.updateTickets(this.state.ticket);
    })
  }

  render() {
    let id=0;
    if (this.props.isLoading) {
      return (
        <p>Loading</p>
      );
    }
    if(!this.props.tickets)
      alert(JSON.stringify(this.props.tickets));

    if(this.props.tickets.length === 0 || this.state.useremail === "")
      return(
        <p>No unassigned tickets available!</p>
      );

    return (
      <div>
        {this.props.tickets.map(ticket => (
          <ListGroup key={id++}>
            <ListGroupItem>
              <Ticket key={ticket.id} data={ticket} />
              <Button value={ticket.id} onClick={() => this.assignTicket(ticket)}>Assign me!</Button>
            </ListGroupItem>
          </ListGroup>
        ))}
      </div>
    );
  }
}