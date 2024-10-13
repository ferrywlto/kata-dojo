import { useEffect, useState } from 'react'
import './App.css'

function App() {
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
  let key = 0;
  const historyList = history.map(h => {
    return (<li key={key++}><button>{h}</button></li>)
  })
  return (<ol>{historyList}</ol>);
}
function GameBoard() {
  const [gameData, setGameData] = useState(initGameData);
  const [round, setRound] = useState(0);
  const [player, setPlayer] = useState('O');
  const [gameEnd, setGameEnd] = useState(false);
  function currentPlayer() {
    if (round % 2 === 0) return 'O';
    else return 'X';
  }
  function initGameData() {
    return new Array(9);
  }
  const checkWinCondition = useEffect(() => {
    let draw = true;
    for (let i = 0; i < lines.length; i++) {
      const line = lines[i];
      if (gameData[line[0]] &&
        gameData[line[0]] === gameData[line[1]] &&
        gameData[line[1]] === gameData[line[2]]) {
        draw = false;
        alert("Winner: " + currentPlayer())
      }
    }
    
    return () => { };
  }, [gameData]);

  useEffect(() => {
    if (round >= 9)
    {
      setGameEnd(true);
    }
  }, [round]);

  function X(id) {
    if (gameEnd) return;
    if (gameData[id]) return;

    setGameData(oldData => {
      const newData = [...oldData];
      newData[id] = currentPlayer();
      return newData;
    });

    setRound(round => round + 1);
  }

  function RenderBoardRows() {
    const rows = [];
    const size = 3; // Assuming a 3x3 grid

    for (let i = 0; i < gameData.length; i += size) {
      const cells = [];
      for (let j = 0; j < size; j++) {
        let idx = i + j;
        cells.push(<Cell key={idx} data={gameData[i + j]} id={idx} onClick={X} />);
      }
      rows.push(
        <div className='row' key={i / size}>
          {cells}
        </div>
      );
    }

    return <>{rows}</>;
  }
  return (
    <>
      <div>Current round: {round}</div>&nbsp;
      <div>Current player: {currentPlayer()}</div>
      <div>{RenderBoardRows()}</div>
    </>
  );
}
function Cell({ data, id, onClick }) {
  function handleClick(e) {
    onClick(id);
  }
  return (<button className='cell' onClick={handleClick}>{data}</button>);
}
export default App;
