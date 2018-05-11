import React from 'react';
import axios from 'axios';
import xmljs from 'xml-js';

class App extends React.Component {
  constructor() {
    super();
    this.handleClick = this.handleClick.bind(this);
    this.handleClick();
  }

  handleClick() {
    axios.get('http://localhost:8000/GetBool')
      .then(response => window.alert(`status:${response.status}, data:${response.data}`))
  }

  render() {
    return(
      <div className="header">
        <h1>Trouble Tickets</h1>
      </div>
    );
  }
}

export default App;
