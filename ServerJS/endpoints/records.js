const fs = require('fs');
module.exports = {
    method: 'GET',
    path: '/records',
    handler: function(req, res) {
        res.send(fs.readFileSync('records.json'));
    }
};