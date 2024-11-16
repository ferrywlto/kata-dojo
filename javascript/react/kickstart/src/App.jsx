import { useState, useEffect, useMemo, useRef } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import Heading from './Heading'
import Section from './Section'

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
      <h2>Learning React - Kickstart with Maid Component</h2>
      <div className="card">
        <Clock />
        <Timer />
        <Page />
      </div>
      <MaidComponent />
    </>
  )
}
function Timer() {
  const [secondsPassed, setSecondPassed] = useState(1);
  const [rows, setRow] = useState(0);
  const thresold = 60;

  function onInterval() {
    setSecondPassed(prev => prev + 1);
  }
  useEffect(() => {
    if (secondsPassed % thresold === 0) {
      setRow(prevRows => prevRows + 1);
    }
  }, [secondsPassed]);
  useEffect(() => {
    const intervalId = setInterval(onInterval, 1000);
    return () => {
      clearInterval(intervalId);
    }
  }, []);

  const fixedRows = useMemo(() => {
    return Array.from({ length: rows }).map((_, i) => (
      <div key={i} className="box-x" style={{ width: `100%` }}></div>
    ));
  }, [rows]);

  return (
    <>
      {fixedRows}
      <div className="box-x" style={{ width: `${(secondsPassed % thresold) / thresold * 100 }%` }}></div>
      You love maid so much, see how many minutes you spent on this page.
    </>
  );
}
function Clock() {
  const [now, setNow] = useState(new Date());
  function timeStr() {
    let date = now;
    return date.getFullYear() + "-" +
      (date.getMonth() + 1).toString().padStart(2, '0') + "-" +
      date.getDate().toString().padStart(2, '0') + " " +
      date.getHours().toString().padStart(2, '0') + ":" +
      date.getMinutes().toString().padStart(2, '0') + ":" +
      date.getSeconds().toString().padStart(2, '0');
  }
  useEffect(() => {
    const intervalId = setInterval(() => {
      setNow(new Date());
    }, 1000);
    
    return () => clearInterval(intervalId);
  }, []);

  return (<h2 >The time now is {timeStr()}</h2>);
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
function AccessoryControl({ accessories, setAccessories }) {
  const [itemName, setItemName] = useState("");
  function handleAddBtnClick() {
    if (!itemName) {
      alert('item name cannot empty');
      return;
    }
    setAccessories(existing => {
      const nextId = existing.reduce((id, item) => item.id > id ? item.id : id, 0) + 1;
      return [...existing, { id: nextId, name: itemName }];
    });
    setItemName("");
  }
  function handleKeyDown(e) {
    if (e.key === "Enter") {
      handleAddBtnClick();
    }
  }
  return (
    <>
      <label>
        Accessory:&nbsp;
        <input type="text" value={itemName} onChange={e => setItemName(e.target.value)}
          onKeyDown={handleKeyDown} />
      </label>&nbsp;
      <input type="button" value="Add" onClick={handleAddBtnClick} />
    </>
  )
}
function AccessoryList({ accessories, setAccessories }) {
  function handleRemoveListItem(itemId) {
    setAccessories(existing => {
      return existing.filter(x => x.id !== itemId);
    })
  }
  function getListItems() {
    return accessories.map((item, idx) => (
      <li key={idx}>
        {item.name}&nbsp;<input type="button" value="x" onClick={_ => handleRemoveListItem(item.id)} />
      </li>)
    );
  }
  const list = useMemo(() => {
    return (<ul>{ getListItems() }</ul>); 
  }, [accessories]);

  return (list);
}
function MaidComponent() {
  const [name, setName] = useState("私のメイドエレイン❥");
  const [wearHairdress, setWearHairdress] = useState(false);
  const [style, setStyle] = useState("mass");
  const [accessories, setAccessories] = useState(defaultAccessories);

  function defaultAccessories() {
    return [{
      id: 1,
      name: "lace stocking"
    }, {
      id: 2,
      name: "mary jane shoes"
    }];
  }

  function GetStyle() {
    if (style === 'mass') return <Mass />;
    else return <Mine />;
  }
  function handleHairDressChange(e) {
    setWearHairdress(e.target.checked);
  }
  function handleDressStyleChange(e) {
    setStyle(e.target.value);
  }
  return (
    <div style={{ textAlign: "left" }} className="card">
      <NameControl name={name} setName={setName} />
      <br />
      <label>
        <input type="checkbox" checked={wearHairdress} onChange={handleHairDressChange} />
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
      <AccessoryControl accessories={accessories} setAccessories={setAccessories} />
      <h1 className="maid-text">How are you my maid {name}?</h1>

      <h2>My maid will wear {GetStyle()} {wearHairdress && " plus Hairdress "} today!</h2>
      <h3>My maid will also wear these accessories:</h3>
      <AccessoryList accessories={accessories} setAccessories={setAccessories} />
    </div>
  )
}
function NameControl({name, setName})
{
  function handleNameChange(e) {
    setName(e.target.value);
  }
  return (
  <label>
    What's my Maid's name?&nbsp;
    <input type="text" value={name} onChange={handleNameChange} />
  </label>
  );
}

export function Page() {
  return (
    <Section >
      <Heading >Menu</Heading>
      <Section >
        <Heading >About</Heading>
        <Heading >Projects</Heading>
        <Heading >Team</Heading>
        <Section >
          <Heading >Sheldon</Heading>
          <Heading >Shamy</Heading>
          <Heading >Seven</Heading>
        </Section>
      </Section>
    </Section>
  )
}
export default App
