import React, { Component } from 'react';
import { FormControl, FormGroup, ControlLabel, Grid, Row, Col } from 'react-bootstrap';
import ListUserOptions from '../globalComponents/ListUserOptions';
import UserSelector from '../globalComponents/UserSelector';
import OwnedTickets from './OwnedTickets';

export default class VisualizeTicketsScreen extends Component {
    constructor(props) {
      super(props);
      this.handleChange = this.handleChange.bind(this);

      this.state = {
          user: "",
      };
    }

    componentDidMount() {
      console.log("User:");
      console.log(this.state.user);
    }

    handleChange(event) {
      console.log("Event");
      console.log(event.target.value);
      this.setState({
        user: event.target.value,
      })
      console.log(this.state);
    }


    render() {
        console.log("Render:");
        console.log(this.state);
        return (
          <div className="container">
            <h1>Tickets Emmited</h1>
            <form>
              <UserSelector value={this.state.user} onChange={this.handleChange} userType="Worker"/>
            </form>

            <Grid>
              <Row className="show-grid">
                <Col>
                  {this.state.user !== "" && 
                  <OwnedTickets useremail={this.state.user}/>}
                </Col>
              </Row>
            </Grid>
          </div>
        );
      }
}