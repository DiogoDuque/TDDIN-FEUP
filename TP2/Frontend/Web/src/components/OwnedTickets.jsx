import React from 'react';
import Ticket from '../globalComponents/Ticket';
import axios from 'axios';

export default class OwnedTickets extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
          tickets: null,
          isLoading: true,
        };
    }

    componentDidUpdate(prevProps, prevState) {
        console.log(this.props.useremail);
        if(this.props.useremail != prevProps.useremail)
          this.updateTickets(this.props.useremail);
      }
    
    componentDidMount() {
        console.log(this.props.useremail);
        this.updateTickets(this.props.useremail);
    }

    updateTickets(useremail) {
        console.log(useremail);
        axios.get(`http://localhost:8000/GetAllTicketsFromAuthor?useremail=${useremail}`)
          .then(response => {
            console.log({response});
            let tickets = response.data;
            this.setState({
              isLoading: false,
              tickets,
            });
          });
    }

    render(){
        console.log(this.state.tickets);
        if(this.state.tickets !== null)
        {
            return(
                <div>
                    {this.state.tickets.map(ticket => (
                        <Ticket key={ticket.description+ticket.creationDate} data={ticket} viewer="Worker"/> 
                    ))}
                </div>
            )
        }
        else
        {
            return <div />
        }
    }
}