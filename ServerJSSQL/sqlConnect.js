const mysql = require("mysql2");


var con = mysql.createConnection({
    host: "localhost",
    user: "server",
    password: "RiskiInsurance"
});

con.connect(function(err) {
    if (err) throw err;
    console.log("Connected!");
    con.query("USE RiskiInsurance", ()=>{console.log("Using database RiskiInsurance")});
});

module.exports = {
	con: con
}