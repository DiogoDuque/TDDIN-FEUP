import React from 'react';
import { ListGroup, ListGroupItem, Row, Col } from 'react-bootstrap';

export default class Ticket extends React.Component {
  render() {
    return (
      <ListGroup>
        <ListGroupItem>
          <Row className="show-grid">
            <Col md={5}>{this.props.data.author}</Col>
            <Col md={3}>{this.props.data.status}</Col>
            <Col md={4}>{this.props.data.creationDate}</Col>
          </Row>
        </ListGroupItem>
        <ListGroupItem>
          <p>{this.props.data.description}</p>
        </ListGroupItem>
      </ListGroup>
    );
  }
}