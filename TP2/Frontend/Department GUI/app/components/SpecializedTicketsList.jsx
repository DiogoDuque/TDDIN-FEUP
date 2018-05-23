import React from 'react';
import axios from 'axios';
import Ticket from '../globalComponents/Ticket';
import amqp from 'amqplib/callback_api';

export default class SpecializedTicketsList extends React.Component {
  constructor(props) {
    super(props);
    this.getQuestions = this.getQuestions.bind(this);
    this.state = {
      tickets: [],
      isLoading: true,
    };
  }

  getQuestions() {
    axios.get('http://localhost:8000/GetTicketsForUnansweredSpecializedQuestions')
      .then(response => {
        console.log(response);
        let tickets = response.data;
        this.setState({
          isLoading: false,
          tickets,
        });
      });
  }

  submitAnswerToQuestion(ticketId, answer) {
    let obj = {
      ticketId,
      answer,
    }
    axios({
      url: 'http://localhost:8000/AnswerSpecializedQuestion',
      method: 'put',
      data: obj,
    })
    .then(response => {
        alert('Submitted!');
        this.getQuestions();
    })
  }

  uintToString(uintArray) {
    var encodedString = String.fromCharCode.apply(null, uintArray),
        decodedString = decodeURIComponent(escape(encodedString));
    return decodedString;
}
  receiveTicketFromQueue(ticket) {
    const { tickets } = this.state;
    tickets.push(ticket);
    this.setState({
      tickets,
    });
  }

  componentDidMount() {
    this.getQuestions();
    const thisTmp = this;

    // establish MQ for receiving questions
    amqp.connect('amqp://localhost', function (err, conn) {
      conn.createChannel(function (err, ch) {
        var q = 'Department';
        ch.assertQueue(q, { durable: false });
        ch.consume(q, t => {
          let ticket = JSON.parse(thisTmp.uintToString(t.content));
          thisTmp.receiveTicketFromQueue(ticket);
        }, {noAck: true});
      });
    });
  }

  editAnswer(text, index) {
    const { tickets } = this.state;
    const questions = tickets[index].questions;
    for(let q of questions) {
      if(!q.answer){
        q.tmpAnswer=text;
        break;
      }
    }
    this.setState({tickets});
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
        {this.state.tickets.map((ticket, index) => (
          <Ticket key={ticket.description + ticket.creationDate} viewer="Department" data={ticket} solver={this.props.username} onChangeAnswer={e => this.editAnswer(e.target.value, index)} submitAnswerToQuestion={(ticketId, answer) => this.submitAnswerToQuestion(ticketId, answer)} />
        ))}
      </div>
    );
  }
}