# React + Vite

This template provides a minimal setup to get React working in Vite with HMR and some ESLint rules.

Currently, two official plugins are available:

- [@vitejs/plugin-react](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react/README.md) uses [Babel](https://babeljs.io/) for Fast Refresh
- [@vitejs/plugin-react-swc](https://github.com/vitejs/vite-plugin-react-swc) uses [SWC](https://swc.rs/) for Fast Refresh

## Steps in creating the minimum unit test enabled React project with Jest

### 1. Create this project

```
npm create vite@latest . -- --template react
npm install
npm run dev
```

### 2. Install Jest
```shell
npm install --save-dev jest
```
Config Jest:
```json
// package.json
{
  "scripts": {
    "test": "jest"
  },
  "jest": {
    "testEnvironment": "node"
  }
}
```

Test if Jest works:
```javascript
// some-code.test.js
test('1 + 1 should equals 2', () => {
  expect(1 + 1).toBe(2);
});
```

## 3. Test with ES6 class
Install Babel
```shell
npm install --save-dev @babel/preset-env @babel/preset-react babel-jest
```
Create `.babelrc`
```json
// .babelrc
{
  "presets": ["@babel/preset-env", "@babel/preset-react"]
}
```
Config Jest:
```json
// package.json
{
  "jest": {
    "transform": {
      "^.+\\.jsx?$": "babel-jest"
    }
  }
}
```
Verify Jest works with class:
```javascript
import Hello from './hello';

test('hello', () => {
    expect(new Hello()).not.toBeNull();
});
```