import { useState } from 'react'
import './App.css'

function App() {
  return (
    <div style={{ display: "flex" }}>
      <GameBoard />
    </div>
  )
}
function GameInformation({ end, round, currentPlayer, winner, handleResetClick }) {
  function RenderGameEnd() {
    return (
      <>
        { RenderWinner() }< br />
        <button onClick={handleResetClick}>Click here to reset</button>
      </>
    )
  }
  function RenderWinner() {
    return winner === null
      ? <label>Draw Game.</label>
      : <label>Winner is {winner}.</label>;
  }
  function RenderGameInProgress() {
    return (
      <>
        <label>Current round: {round + 1}</label><br />
        <label>Current player: {currentPlayer}</label>
      </>
    );
  }
  return (
    <div style={{ textAlign: "start" }}>
      {(end || round >= 9) ? RenderGameEnd() : RenderGameInProgress()}
    </div>
  );
}

function GameBoard() {

  const [current, setCurrent] = useState(emptyBoard);
  const [history, setHistory] = useState([]);
  const [round, setRound] = useState(0);
  const [end, setEnd] = useState(false);
  const [winner, setWinner] = useState(null);

  function emptyBoard() {
    return new Array(9).fill(null);
  }

  function currentPlayer() {
    if (round % 2 === 0) return 'O';
    else return 'X';
  }

  function TimeMachine(h) {
    setRound(h + 1);
    setCurrent(history[h]);
    if (h < 9) {
      setEnd(false);
    }
  }
  function HandleCellClick(id) {
    if (end) return;
    if (round >= 9) return;
    if (current[id]) return;

    const next = [...current];
    next[id] = currentPlayer();

    setCurrent(next);
    setHistory(oldHistory => {
      return [...oldHistory.slice(0, round), next];
    });

    const winner = checkWinCondition(next);
    if (winner) {
      setWinner(currentPlayer());
      setEnd(true);
    }
    else if (round == 8) {
      setEnd(true);
    }

    setRound(round => round + 1);
  }
  function HandleResetClick() {
    setCurrent(emptyBoard());
    setRound(0);
    setHistory([]);
    setEnd(false);
  }
  function RenderBoardRows() {
    const rows = [];
    const size = 3; // Assuming a 3x3 grid

    for (let i = 0; i < current.length; i += size) {
      const cells = [];
      for (let j = 0; j < size; j++) {
        let idx = i + j;
        cells.push(<Cell key={idx} data={current[i + j]} onClick={() => HandleCellClick(idx)} />);
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
      <div>
        <div>{RenderBoardRows()}</div>
      </div>
      <div>
        <GameInformation end={end} round={round} currentPlayer={currentPlayer()} handleResetClick={HandleResetClick} winner={winner}/>
        <GameHistory history={history} timeMachine={TimeMachine} />
      </div>
    </>
  );
}

function GameHistory({ history, timeMachine }) {
  const historyList = history.map((h, idx) => {
    return (<li key={idx}><button onClick={() => timeMachine(idx)}>picks cell.</button></li>)
  })
  return (<ol>{historyList}</ol>);
}

function Cell({ data, id, onClick }) {
  return (<button className='cell' onClick={onClick}>{data}</button>);
}

const lines = [
  [0, 1, 2], [3, 4, 5], [6, 7, 8],
  [0, 3, 6], [1, 4, 7], [2, 5, 8],
  [0, 4, 8], [2, 4, 6]
]
function checkWinCondition(data) {
  for (let i = 0; i < lines.length; i++) {
    const [a, b, c] = lines[i];
    if (data[a] &&
      data[a] === data[b] &&
      data[a] === data[c]) {
      return data[a];
    }
  }
  return null;
}
export default App;
