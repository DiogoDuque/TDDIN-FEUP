import React from 'react';
import { ListGroup, ListGroupItem, Grid, Row, Col } from 'react-bootstrap';
import TicketsNavbar from '../globalComponents/TicketsNavbar';
import SpecializedTicketsList from './SpecializedTicketsList';

class App extends React.Component {
  constructor() {
    super();
  }

  render() {
    return (
      <div>
        <TicketsNavbar screenName="Department Edition" />
        <SpecializedTicketsList/>
      </div>
    );
  }
}

export default App;
