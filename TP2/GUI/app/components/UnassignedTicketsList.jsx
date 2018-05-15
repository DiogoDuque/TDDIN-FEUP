import React from 'react';
import axios from 'axios';
import Ticket from './Ticket';

export default class AssignedTickets extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      tickets: null,
      isLoading: true,
    };
  }

  componentDidMount() {
    axios.get('http://localhost:8000/GetUnassignedTickets')
      .then(response => {
        console.log(response);
        let tickets = response.data;
        this.setState({
          isLoading: false,
          tickets,
        });
      });
  }

  render() {
    if (this.state.isLoading) {
      return (
        <p>Loading</p>
      );
    }

    return (
      <div>
        {this.state.tickets.map(ticket => (
          <Ticket key={ticket.description+ticket.creationDate} data={ticket} />
        ))}
      </div>
    );
  }
}