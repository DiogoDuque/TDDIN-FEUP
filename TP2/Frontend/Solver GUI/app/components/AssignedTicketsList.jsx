import React from 'react';
import axios from 'axios';
import Ticket from '../globalComponents/Ticket';
import { Button, ListGroup, ListGroupItem, FormGroup, FormControl, ControlLabel } from 'react-bootstrap';


export default class AssignedTickets extends React.Component {
  constructor(props) {
    super(props);
    
    this.sendQuestion = this.sendQuestion.bind(this);
    this.handleChangeForms = this.handleChangeForms.bind(this);
    this.closeTicket = this.closeTicket.bind(this);
    this.state = {
      page: this.props.page,
      forms: {},
    };
  }

  componentDidMount() {
    this.setState({
      page: this.state.page,
      forms: this.state.forms,
    });
  }

  

  sendQuestion(ticketid){
    let obj = {
      id: ticketid,
      question: this.state.forms[ticketid].text,
      creationDate: ""
    }
    console.log("Send Question");
    console.log(obj);
    if(obj !== null && obj !== undefined)
    {
      axios({
        url: "http://localhost:8000/AskSpecializedQuestion",
        method: 'post',
        data: obj,
        crossDomain: true,
      })
      .then(response => {
        this.props.updateTickets(this.state.useremail);
      })
    }
  }

  closeTicket(ticket) {
    console.log("Closing Ticket");
    console.log(ticket);

    let obj = {
      ticketId : ticket.id,
      emailtext: this.state.forms[ticket.id].text,
    }
    axios({
      url: "http://localhost:8000/CloseTicket",
      method: 'put',
      data: obj,
      crossDomain: true,
    })
    .then(response => {
      if(response) {
        alert("Close ticket successfully");
      } else {
        alert("Error: Could not close ticket");
      }
      this.props.updateTickets(this.state.useremail);
    });
  }

  handleChangeForms(event, ticketid){
    console.log(this.state.forms);
    var newforms = this.state.forms;
    newforms[ticketid] = {
      id: ticketid,
      text: event.target.value,
      creationDate: "",
    }
    this.setState({
      forms : newforms,
    })
  }

  render() {
    if (this.props.isLoading) {
      return (
        <p>Loading</p>
      );
    }

    if(this.props.tickets == null || this.props.tickets == "") {
      return (
        <p>No assigned tickets available!</p>
      );
    }

    if(this.state.page === 'VisualizeTickets')
    {
      var other = this;
      return (
        <div>
          {this.props.tickets.map(function(ticket) {
            if(ticket.status !== "Solved")
            {
              return (
              <ListGroup>
                <ListGroupItem>
                  <Ticket key={ticket.id} data={ticket} />
                </ListGroupItem>
                
                <ListGroupItem>
                  <FormGroup>
                    <FormControl componentClass="textarea" rows="4" placeholder="Write the answer here..." onChange={event => other.handleChangeForms(event, ticket.id)}/>
                  </FormGroup>
                  <Button onClick={() => other.closeTicket(ticket)}>Send and Close</Button>
                </ListGroupItem>
                
              </ListGroup>
            );
          } else {
            return "";
          }
          })}

        </div>
      );
    } else if(this.state.page === 'AskDepartment') {
      var other = this;
      return (
        <div>
          {this.props.tickets.map(function(ticket) {
            return (
            <ListGroup>
              <ListGroupItem>
                <Ticket key={ticket.id} data={ticket} />
              </ListGroupItem>
              <ListGroupItem>
                {ticket.questions.map(function(question) {
                  return(
                    <ListGroup>
                      <ListGroupItem header="Question">
                        <strong>{question.question}</strong>
                      </ListGroupItem>
                      {question.answer !== null &&
                      <ListGroupItem>
                        {question.answer}
                      </ListGroupItem>
                      }
                    </ListGroup>
                  );
                })}
              </ListGroupItem>
              <ListGroupItem>
                <FormGroup>
                  <FormControl componentClass="textarea" rows="4" placeholder="Write your question here..." onChange={event => other.handleChangeForms(event, ticket.id)}/>
                </FormGroup>
                <Button value={ticket.id} onClick={() => other.sendQuestion(ticket.id)}>Send question</Button>
              </ListGroupItem>
            </ListGroup>
            );
          })}

        </div>
      );
    }
  }
}