const fs = require('fs');
module.exports = {
    method: 'GET',
    path: '/testConnection',
    handler: function(req, res) {
		res.send("");
    }
};