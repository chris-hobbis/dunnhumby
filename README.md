# dunnhumby - Build & Run Guide

## Prerequisites

Before starting, ensure you have the following installed on your system:

- **Node.js** (v16 or later) - Download from [nodejs.org](https://nodejs.org/)
- **npm** (Node Package Manager) - Comes with Node.js
- **bash** (Linux/macOS users have it by default; Windows users can use Git Bash or WSL)

## Setup Instructions - React

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

# .NET Core WebAPI - Build & Run Guide

This guide provides instructions on setting up, building, and running a .NET Core WebAPI project that runs on `http://localhost:5179/`.

## Prerequisites

Ensure you have the following installed:

- **.NET SDK** (Latest stable version) - Download from [dotnet.microsoft.com](https://dotnet.microsoft.com/)
- **Visual Studio** (Optional but recommended) or any preferred code editor
- **Git** (for version control)

## Setup Instructions - WebAPI

### 1. Clone the Repository

If you haven’t already, clone the project repository:

```bash
 git clone https://github.com/chris-hobbis/dunnhumby.git
 cd dunnhumby
```

### 2. Restore Dependencies

Run the following command to restore required dependencies:

```bash
 dotnet restore
```

### 3. Run the WebAPI

Start the application with:

```bash
 dotnet run
```

This will start the API on `http://localhost:5179/` by default.

### 4. Building the Project

To create a compiled version of the application:

```bash
 dotnet build
```

The output will be placed in the `bin/Debug/netX.X/` directory.

### 5. Swagger API Documentation

Swagger is enabled, you can access API documentation at:

```
http://localhost:5179/swagger/index.html
```
