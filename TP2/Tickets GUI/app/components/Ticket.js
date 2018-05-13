import React from 'react';
import { ListGroup, ListGroupItem, Grid, Row, Col } from 'react-bootstrap';

export default class Ticket extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <ListGroup>
        <ListGroupItem>
          <Row className="show-grid">
            <Col md={5}>{this.props.data.author}</Col>
            <Col md={5}>{this.props.data.status}</Col>
            <Col md={2}>{this.props.data.creationDate}</Col>
          </Row>
        </ListGroupItem>
        <ListGroupItem>
          <p>{this.props.data.description}</p>
        </ListGroupItem>
      </ListGroup>
    );
  }
}