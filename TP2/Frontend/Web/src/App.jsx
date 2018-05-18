import React, { Component } from 'react';
import TicketsNavbar from './globalComponents/TicketsNavbar';
import AskQuestionScreen from './components/AskQuestionScreen';

class App extends Component {
  render() {
    return (
      <div>
        <TicketsNavbar screenName="Worker Edition" />
        <AskQuestionScreen />
      </div>
    );
  }
}

export default App;
