const express = require('express');
const fs = require('fs');
const app = express();
app.use(express.bodyParser());
const port = 3000;

app.post('/addRecord', (req, res) => {
    let record = req.body.Record;
    let records = fs.readFileSync('./Records.json');
    records.push(record);
    fs.writeFile('./Records.json',JSON.stringify(records));
});

app.listen(port, () => console.log(`Example app listening on port ${port}!`));