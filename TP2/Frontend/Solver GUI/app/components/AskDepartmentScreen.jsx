import React, { Component } from 'react';
import { Grid, Col, Row, InputGroup, FormControl, Button } from 'react-bootstrap';
import UserSelector from '../globalComponents/UserSelector';
import AssignedTickets from './AssignedTicketsList';

export default class AskDepartment extends Component {
    constructor(props) {
        super(props);

        this.handleChangeMainPage = this.props.handleChange;
        this.handleChange = this.handleChange.bind(this);
        this.state = {
            page: this.props.page,
            solver: this.props.solver,
        }
    }

    componentDidUpdate(prevProps, prevState) {
    }

    handleChange(event) {
        this.handleChangeMainPage(event);
        this.setState({
          solver: event.target.value,
        })
      }


    render() {
        return(
            <div className="container">

                <form>
                <UserSelector userType="Solver" onChange={this.handleChange} value={this.state.solver} />
                </form>
                <Grid>
                <Row className="show-grid">
                    <Col md={10}>
                        <AssignedTickets useremail={this.state.solver} page={this.state.page}/>
                    </Col>
                </Row>
                </Grid>
            </div>
        )
    }
}