const express = require('express');
// Bodyparser is not included in express anymore, so you need to import it seperately
const bodyParser = require('body-parser');
const fs = require('fs');
const app = express();
app.use(bodyParser.text());
const port = 3000;
let records = fs.readFileSync('../Server/records.json');

for (let file of fs.readdirSync('./endpoints')) {
    endpoint = require(`./endpoints/${file}`);
    app[endpoint.method.toLowerCase()](endpoint.path, endpoint.handler);
}
// Maybe we could use a database?
app.listen(port, () => console.log(`Server started on port ${port}!`));