const fs = require('fs');
module.exports = {
    method: 'POST',
    path: '/addRecord',
    handler: function(req, res) {
        let records = JSON.parse(fs.readFileSync('../Server/records.json'));
        let record = JSON.parse(req.body);
        records.push(record);
        fs.writeFileSync('../Server/records.json', JSON.stringify(records, null, 4));
        res.send('Record added!');
    }
};