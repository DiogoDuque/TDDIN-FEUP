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

  componentDidMount() {
    axios.get('http://localhost:8000/GetUnassignedTickets')
      .then(response => {
        console.log({title:"Unassigned",response});
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

    if(this.state.tickets.length === 0)
      return(
        <p>No unassigned tickets available!</p>
      );

    return (
      <div>
        {this.state.tickets.map(ticket => (
          <Ticket key={ticket.description+ticket.creationDate} data={ticket} solver={this.props.username} />
        ))}
      </div>
    );
  }
}