const fs = require('fs');
const {con} = require('../sqlConnect.js');
module.exports = {
    method: 'GET',
    path: '/records',
    handler: function(req, res) {
        con.query('SELECT * FROM ClientRecords' , (err,result) =>{
            res.send(result);
        });
    }
};