import React from 'react';
import { ListGroup, ListGroupItem, Row, Col, FormControl, Button } from 'react-bootstrap';

export default class Ticket extends React.Component {

  render() {
    const ticket = this.props.data;
    let id = 0;
    return (
      <ListGroup>
        <ListGroupItem>
          <Row className="show-grid">
            <Col md={5}>Author: {ticket.author}</Col>
            <Col md={4}>{ticket.creationDate}</Col>
            <Col md={3}>{ticket.status}</Col>
          </Row>
        </ListGroupItem>
        <ListGroupItem>
          <h4>{ticket.title}</h4>
          <p>{ticket.description}</p>
        </ListGroupItem>
        {(ticket.status !== 'Unassigned' && this.props.viewer !== "Worker") && (
          <ListGroupItem>
            <Row className="show-grid">
              <Col md={5}>Solver: {ticket.solver}</Col>
              {ticket.status === 'Solved' && (
                <Col md={4}>{ticket.answer}</Col>
              )}
            </Row>
          </ListGroupItem>
        )}
        {(this.props.viewer === 'Worker' || this.props.viewer === 'Department') && (
          <ListGroupItem>
            {ticket.questions.map(q => (
              <div key={id++}>
                <ListGroupItem>
                  <h4>Question</h4>
                  <p>{q.question}</p>
                </ListGroupItem>
                {q.answer && (
                  <ListGroupItem>
                    <h4>Answer</h4>
                    <p>{q.answer}</p>
                  </ListGroupItem>
                )}
                {(this.props.viewer === 'Department' && !q.answer) && (
                  <form>
                    <h4>Answer</h4>
                    <FormControl key={id++} type="text" value={ticket.tmpAnswer} placeholder="Give an answer" onChange={this.props.onChangeAnswer} />
                    <Button onClick={() => this.props.submitAnswerToQuestion(ticket.id, ticket.tmpAnswer)}>Submit</Button>
                  </form>
                )}
              </div>
            ))}
          </ListGroupItem>
        )}
      </ListGroup>
    );
  }
}