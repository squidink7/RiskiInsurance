# RiskiInsurance

Insurance quote calculator for Riski Jet-Ski Insurance


## Live Demo

https://riski.fryer.net.au/

## Dependencies

[MariaDB](https://mariadb.org/): used for database on server

[Nodejs](https://nodejs.org/en): used for running either ServerJS & ServerJSSQL

[Dotnet](https://dotnet.microsoft.com/en-us/): used for building the client

## Server database setup
On the same machine that the server script will be running run the SetupDB.sh file


### Building

This repo contains the code for the Server and Client, with build instructions as follows
To build, run the following commands in the root of their respective folders

### Client

**Run:**
```
dotnet run
```

**Build:**
```
dotnet publish -c Release
```

### ServerJS & ServerJSSQL

**Run:**
```
npm i
node index.js
```

**Build:**
N/A

### ServerV

**Run:**
```
v run .
```

**Build:**
```
v -prod .
```
