import React from 'react';
import { ListGroup, ListGroupItem, Row, Col } from 'react-bootstrap';

export default class Ticket extends React.Component {
  render() {
    const ticket = this.props.data;
    return (
      <ListGroup>
        <ListGroupItem>
          <Row className="show-grid">
            <Col md={5}>Author: {ticket.authorname}</Col>
            <Col md={4}>{ticket.creationDate}</Col>
            <Col md={3}>{ticket.status}</Col>
          </Row>
        </ListGroupItem>
        <ListGroupItem>
          <h4>{ticket.title}</h4>
          <p>{ticket.description}</p>
        </ListGroupItem>
        {ticket.status !== 'Unassigned' && (
          <ListGroupItem>
            <Row className="show-grid">
              <Col md={12}>Solver: {ticket.solvername}</Col>
              {ticket.status === 'Solved' && (
                <Col md={4}>{ticket.answer}</Col>
              )}
            </Row>
          </ListGroupItem>
        )}
      </ListGroup>
    );
  }
}