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

  componentDidUpdate(prevProps, prevState) {
    if(this.props.username != prevProps.username)
      this.updateTickets(this.props.username);
  }

  componentDidMount() {
    this.updateTickets(this.props.username);
  }

  updateTickets(username) {
    axios.get(`http://localhost:8000/GetAllTicketsFromSolver?username=${username}`)
      .then(response => {
        console.log({title:"Assigned",response});
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