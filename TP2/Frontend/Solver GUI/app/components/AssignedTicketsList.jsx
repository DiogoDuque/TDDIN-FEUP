import React from 'react';
import axios from 'axios';
import Ticket from '../globalComponents/Ticket';

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
    console.log("Render Assigned Tickets");
    console.log(this.state.tickets);
    if (this.state.isLoading) {
      return (
        <p>Loading</p>
      );
    }

    if(this.state.tickets !== null) {
      return (
        <p>No assigned tickets available!</p>
      );
    }

    return (
      <div>
        {this.state.tickets.map(function(ticket) {
          return <Ticket key={ticket.description+ticket.creationDate} data={ticket} />;
        })}

      </div>
    );
  }
}