import React, { Component } from 'react';
import TicketsNavbar from './globalComponents/TicketsNavbar';
import AskQuestionScreen from './components/AskQuestionScreen';
import RegisterScreen from './components/RegisterScreen';
import VisualizeTicketsScreen from './components/VisualizeTicketsScreen';

class App extends Component {
  constructor(props) {
    super(props);
    this.changePage = this.changePage.bind(this);
    this.state = {
      page: 'Register',
    }
  }

  changePage(key) {
    if (key === this.state.page)
      return;

    this.setState({
      page: key,
    });
  }

  render() {
    return (
      <div>
        <TicketsNavbar changePage={this.changePage} screenName="Worker Edition" />
        {this.state.page === 'Register' &&
          <RegisterScreen/>}
        {this.state.page === 'AskQuestion' &&
          <AskQuestionScreen />}
        {this.state.page === 'VisualizeTickets' &&
          <VisualizeTicketsScreen />}
      </div>
    );
  }
}

export default App;
