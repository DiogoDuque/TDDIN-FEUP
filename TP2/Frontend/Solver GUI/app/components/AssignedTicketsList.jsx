import React from 'react';
import axios from 'axios';
import Ticket from '../globalComponents/Ticket';
import { Button, ListGroup, ListGroupItem, FormGroup, FormControl, ControlLabel } from 'react-bootstrap';


export default class AssignedTickets extends React.Component {
  constructor(props) {
    super(props);
    
    this.sendQuestion = this.sendQuestion.bind(this);
    this.handleChangeForms = this.handleChangeForms.bind(this);
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
    let obj = this.state.forms[ticketid];
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
        this.updateTickets(this.state.useremail);
      })
    }
  }

  handleChangeForms(event, ticketid){
    console.log(this.state.forms);
    var newforms = this.state.forms;
    newforms[ticketid] = {
      id: ticketid,
      question: event.target.value,
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
      return (
        <div>
          {this.props.tickets.map(function(ticket) {
            return <Ticket key={ticket.id} data={ticket} />;
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