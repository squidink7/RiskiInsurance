const fs = require('fs');
const {con} = require('../sqlConnect.js');
module.exports = {
    method: 'DELETE',
    path: '/deleteRecord',
    handler: function(req, res) {
        let {ID} = req.query
        let sql = `
            DELETE FROM ClientRecords WHERE ID = "${ID}";
        `;
        con.query(sql, function(err, result) {
            res.send('Record deleted!');
        });
    }
};