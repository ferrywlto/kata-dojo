import { useState } from 'react'
import './App.css'

function App() {
  const [count, setCount] = useState(0)

  return (
    <div style={{ display: "flex" }}>
      <GameBoard />
      <GameHistory />
    </div>
  )
}
const lines = [
  [0, 1, 2], [3, 4, 5], [6, 7, 8],
  [0, 3, 6], [1, 4, 7], [2, 5, 8],
  [0, 4, 8], [2, 4, 6]
]
function GameHistory() {
  const [history, setHistory] = useState([
    'hi', 'how', 'are', 'you', 'my', 'maid?'
  ]);
  const historyList = history.map(h => {
    return (<li><button>{h}</button></li>)
  })
  return (<ol>{historyList}</ol>);
}
function GameBoard() {
  const [gameData, setGameData] = useState(initGameData);
  const [round, setRound] = useState(0);
  function initGameData() {
    return new Array(9);
  }
  function checkWin() {
    for (let line in lines) {
      if (gameData[line[0]] === gameData[line[1]] === gameData[line[2]]) return gameData[line[0]];
    }

  }
  return (
    <div>
      <div className='row'>
        <Cell />
        <Cell />
        <Cell />
      </div>
      <div className='row'>
        <Cell />
        <Cell />
        <Cell />
      </div>
      <div className='row'>
        <Cell />
        <Cell />
        <Cell />
      </div>      
    </div>
  );
}
function Cell() {
  const [text, setText] = useState('');

  return (<div className='cell'>h1</div>);
}
export default App;
