import React from 'react';
import axios from 'axios';
import Ticket from '../globalComponents/Ticket';

export default class AssignedTickets extends React.Component {
  constructor(props) {
    super(props);
    console.log("Contructor Assigned Tickets: " + this.props.useremail);
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
    console.log("Update Tickets (Assigned): " + useremail);
    axios.get(`http://localhost:8000/GetAllTicketsFromSolver?useremail=${useremail}`)
      .then(response => {
        console.log({title:"Assigned",response});
        let tickets = response.data;
        this.setState({
          isLoading: false,
          tickets,
          useremail,
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

    if(this.state.tickets == null || this.state.tickets == "") {
      return (
        <p>No assigned tickets available!</p>
      );
    }

    console.log("Before");
    console.log(typeof(this.state.tickets));
    console.log(this.state.tickets == null);
    return (
      <div>
        {this.state.tickets.map(function(ticket) {
          return <Ticket key={ticket.id} data={ticket} />;
        })}

      </div>
    );
  }
}