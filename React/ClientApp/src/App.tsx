import React from 'react';
import './App.css';
import { Button } from 'antd';

function App() {
  function maxWindow() {
    fetch('/window/max',{
      method: 'post'
    })
  }
  return (
    <div className="App">
      <Button type="primary" onClick={maxWindow}>Button</Button>
    </div>
  );
}

export default App;
