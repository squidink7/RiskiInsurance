const fs = require('fs');
module.exports = {
    method: 'DELETE',
    path: '/deleteRecord',
    handler: function(req, res) {
        let {ID} = req.query
        records = records.filter(record => record.ID !== ID);
        fs.writeFileSync('records.json', JSON.stringify(records));
        res.send('Record deleted!');
    }
};