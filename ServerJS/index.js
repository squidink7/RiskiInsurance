const express = require('express');
// Bodyparser is not included in express anymore, so you need to import it seperately
const bodyParser = require('body-parser');
const fs = require('fs');
const app = express();
app.use(bodyParser.text());
const port = 3000;

// Maybe we could use a database?
app.post('/addrecord', (req, res) => {
    let record = JSON.parse(req.body);
    let records = JSON.parse(fs.readFileSync('records.json'));
    records.push(record);
    fs.writeFileSync('records.json', JSON.stringify(records));
});

app.listen(port, () => console.log(`Server started on port ${port}!`));