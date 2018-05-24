import React from 'react';
import axios from 'axios';
import Ticket from '../globalComponents/Ticket';
import amqp from 'amqplib/callback_api';

export default class SpecializedTicketsList extends React.Component {
  constructor(props) {
    super(props);
    this.getQuestions = this.getQuestions.bind(this);
    this.handleChangeForms = this.handleChangeForms.bind(this);
    this.submitAnswerToQuestion = this.submitAnswerToQuestion.bind(this);
    this.state = {
      tickets: [],
      isLoading: true,
      forms: {}, 
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

  submitAnswerToQuestion(ticketId) {
    console.log("Answer: " + this.state.forms[ticketId].text);
    let obj = {
      ticketId,
      answer : this.state.forms[ticketId].text
    }
    axios({
      url: 'http://localhost:8000/AnswerSpecializedQuestion',
      method: 'put',
      data: obj,
      crossDomain: true,
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
  
  handleChangeForms(event, ticketid){
    var newforms = this.state.forms;
    newforms[ticketid] = {
      id: ticketid,
      text: event.target.value,
    }
    console.log(newforms);
    this.setState({
      forms : newforms,
    })
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
          <Ticket key={ticket.description + ticket.creationDate} viewer="Department" data={ticket} solver={this.props.username} submitAnswerToQuestion={this.submitAnswerToQuestion} handleChangeForms={this.handleChangeForms} />
        ))}
      </div>
    );
  }
}