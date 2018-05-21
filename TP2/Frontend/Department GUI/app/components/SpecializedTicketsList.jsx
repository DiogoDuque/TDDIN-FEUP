import React from 'react';
import axios from 'axios';
import Ticket from '../globalComponents/Ticket';
import amqp from 'amqplib/callback_api';

export default class SpecializedTicketsList extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      tickets: [],
      isLoading: true,
    };
  }

  componentDidMount() {
    axios.get('http://localhost:8000/GetSpecializedQuestions')
      .then(response => {
        console.log(response);
        let tickets = response.data;
        this.setState({
          isLoading: false,
          tickets,
        });
      });

    amqp.connect('amqp://localhost', function (err, conn) {
      conn.createChannel(function (err, ch) {
        var q = 'DepartmentQueue';
        ch.assertQueue(q, { durable: false });
        ch.consume(q, t => {
          const { tickets } = this.state;
          tickets.push(t);
          this.setState({
            tickets,
          });
        }, {noAck: true});
      });
    });
  }

  render() {
    if (this.state.isLoading) {
      return (
        <p>Loading</p>
      );
    }

    if (this.state.tickets.length === 0)
      return (
        <p>No unassigned tickets available!</p>
      );

    return (
      <div>
        {this.state.tickets.map(ticket => (
          <Ticket key={ticket.description + ticket.creationDate} data={ticket} solver={this.props.username} />
        ))}
      </div>
    );
  }
}