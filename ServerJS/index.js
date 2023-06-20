const express = require('express');
// Bodyparser is not included in express anymore, so you need to import it seperately
const bodyParser = require('body-parser');
const fs = require('fs');
const app = express();
app.use(bodyParser.text());
const port = 3000;

// Maybe we could use a database?
app.post('/addrecord', (req, res) => {
    let record = req.body.Record;
    let records = fs.readFileSync('records.json');
    records.push(record);
    fs.writeFile('records.json',JSON.stringify(records));
});

app.listen(port, () => console.log(`Example app listening on port ${port}!`));