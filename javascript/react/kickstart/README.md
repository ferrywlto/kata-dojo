# React + Vite

This template provides a minimal setup to get React working in Vite with HMR and some ESLint rules.

Currently, two official plugins are available:

- [@vitejs/plugin-react](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react/README.md) uses [Babel](https://babeljs.io/) for Fast Refresh
- [@vitejs/plugin-react-swc](https://github.com/vitejs/vite-plugin-react-swc) uses [SWC](https://swc.rs/) for Fast Refresh

### Commands to kickstart
This project was created by
```
npm create vite@latest my-react-app -- --template react
npm install
npm run dev
```

### Code execution flow
index.html => script tag => main.jax => getElementById('root') => render App in root div => App.jsx

### CSS Scope
- index.css => Global scope
- App.css => Scope to App component