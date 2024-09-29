import { useState, useEffect, useMemo, useRef } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {
  const [count, setCount] = useState(0)
  return (
    <>
      <div>
        <a href="https://vitejs.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Vite + React</h1>
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
        <p>
          Edit <code>src/App.jsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
      <Clock />
      <Timer />
      <MaidComponent />
    </>
  )
}
function Timer() {
  const [secondsPassed, setSecondPassed] = useState(0);
  const [rows, setRow] = useState(1);
  const thresold = 60;
  
  useEffect(() => {
    let intervalId = setInterval(() => {
      setSecondPassed(prevSec => { 
        let currentSecond = prevSec + 1;
        if (currentSecond % thresold === 0) {
          setRow(prevRow => prevRow + 1);
        }
        console.log(currentSecond);
        return currentSecond;        
      });
    }, 1000);

    // Cleanup interval on component unmount
    return () => {
      console.log(`clearing interval: ${intervalId}`);
      clearInterval(intervalId);
    }
  }, []); // Empty dependency array ensures this runs only once

  const fixedRows = useMemo(() => {
    console.log(`fixedRows: ${rows}`);
    return Array.from({ length: rows }).map((_, i) => (
      <div key={i} className="box-x" style={{ width: `${thresold}px` }}></div>
    ));
  }, [rows]); // Only re-compute when `rows` changes

  return (
    <>
      { fixedRows }
      <div className="box-x" style={{ width: secondsPassed % thresold }}></div>
    </>
  );
}
function Clock() {
  const [now, setNow] = useState(new Date());
  function timeStr() {
    let date = now;
    return date.getFullYear() + "-" +
      (date.getMonth() + 1).toString().padStart(2, '0') +"-" +
      date.getDate().toString().padStart(2, '0') + " " +
      date.getHours().toString().padStart(2, '0') + ":" +
      date.getMinutes().toString().padStart(2, '0') + ":" +
      date.getSeconds().toString().padStart(2, '0');
  }
  useEffect(() => {
    const intervalId = setInterval(() => {
      setNow(new Date());
    }, 1000);

    // Cleanup interval on component unmount
    return () => clearInterval(intervalId);
  }, []); // Empty dependency array ensures this runs only once

  return (<h2 >Time now is {timeStr()}</h2>);
}
function Mass() {
  return (
    <>
      <span style={{ color: "beige" }}>M</span>
      <span style={{ color: "darkgray" }}>a</span>
      <span style={{ color: "beige" }}>s</span>
      <span style={{ color: "darkgray" }}>s</span>
    </>
  );
}
function Mine() {
  return (
    <>
      <span style={{ color: "pink" }}>L</span>
      <span style={{ color: "darkgrey" }}>a</span>
      <span style={{ color: "pink" }}>n</span>
      <span style={{ color: "darkgrey" }}>d</span>      
      <span style={{ color: "pink" }}>m</span>
      <span style={{ color: "darkgrey" }}>i</span>
      <span style={{ color: "pink" }}>n</span>
      <span style={{ color: "darkgrey" }}>e</span>
    </>
  );
}
function MaidComponent() {
  const [name, setName] = useState("Elaine");
  const [wearHairdress, setWearHairdress] = useState(false);
  const [width, setWidth] = useState(100);
  const [list, setList] = useState([1]);
  const [style, setStyle] = useState("mass");

  const items = list.map(item => 
    <li key={item}>{item}</li>
  );
  
  function GetStyle() {
    if (style === 'mass') return <Mass />;
    else return <Mine />;
  }
  function handleBtnClick() 
  {
      let newWidth = width + 3;
      setWidth(newWidth);
      if (newWidth % 2 === 0)
        setStyle("mass");
      else
      setStyle("mine");
  }
  function handleNameChange(e)
  {
    setName(e.target.value);
  }
  function handleHairDressChange(e)
  {
    setWearHairdress(e.target.checked);
  }
  function handleDressStyleChange(e) 
  {
    setStyle(e.target.value);
  }
  return (
    <div style={{textAlign: "left"}}>
      <label>
        What's my Maid's name?&nbsp;
        <input type="text" value={name} onChange={handleNameChange}/>
      </label>
      <br />
      <label>
        <input type="checkbox" checked={wearHairdress} onChange={handleHairDressChange}/>
        Wear hairdress?
      </label>
      <div style={{ display: "flex" }}>
        <label>Dress style:&nbsp;</label>
        <label>
          <input type="radio" id="outfit-mass" name="outfit" value="mass"
            onChange={handleDressStyleChange}
            checked={style === "mass"} />
          Mass
        </label>&nbsp;
        <label>
          <input type="radio" id="outfit-mine" name="outfit" value="mine"
            onChange={handleDressStyleChange}
            checked={style === "mine"} />
          Mine
        </label>
      </div>      
      <h1 className="maid-text">How are you my maid {name}?</h1>
      
      <h2>My maid will wear {GetStyle()} { wearHairdress && " plus Hairdress " } today!</h2>

      <button onClick={handleBtnClick}>Wider</button>
      <div>
        <ul>{items}</ul>
      </div>
    </div>
  )
}
export default App
