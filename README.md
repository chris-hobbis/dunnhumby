# dunnhumby - Build & Run Guide

## Prerequisites

Before starting, ensure you have the following installed on your system:

- **Node.js** (v16 or later) - Download from [nodejs.org](https://nodejs.org/)
- **npm** (Node Package Manager) - Comes with Node.js
- **bash** (Linux/macOS users have it by default; Windows users can use Git Bash or WSL)

## Setup Instructions

### 1. Clone the Repository

If you haven’t already, clone the project repository:

```bash
 git clone https://github.com/chris-hobbis/dunnhumby.git
 cd dunnhumby
```

### 2. Install Dependencies

Run the following command to install the required packages. You may need to use --force:

```bash
 npm install
```

### 3. Run the Development Server

To start the React development server, run:

```bash
 npm run dev
```

This will start the development server, usually at `http://localhost:5173/` (for Vite projects) or `http://localhost:5173/` (for Create React App projects).

### 4. Build the Project for Production

To create an optimized production build, use:

```bash
 npm run build
```

This will generate the production-ready files inside the `dist` (for Vite) or `build` (for Create React App) folder.

### 5. Serve the Production Build

To test the production build locally:

```bash
 npm install -g serve
 serve -s dist  # or 'build' for Create React App
```

This will serve the app on a local server, typically at `http://localhost:5173/`.