const fs = require('fs');
const {con} = require('../sqlConnect.js');

module.exports = {
    method: 'POST',
    path: '/addRecord',
    handler: function(req, res) {
        let record = JSON.parse(req.body);
        let sql = `
            INSERT INTO ClientRecords
            (
                ID,
                TimeStampUnix,
                RiderName,
                RiderAge,
                RiderExperience,
                SkiPower,
                SkiSeats,
                SkiPrice,
                SkiAge,
                Excess,
                Total
            )
            VALUES
            (
                ("${record.ID}"),
                ("${record.TimeStampUnix}"),
                ("${record.RiderName}"),
                ("${record.RiderAge}"),
                ("${record.RiderExperience}"),
                ("${record.SkiPower}"),
                ("${record.SkiSeats}"),
                ("${record.SkiPrice}"),
                ("${record.SkiAge}"),
                ("${record.Excess}"),
                ("${record.Total}")
            );
        `
        con.query(sql, function(err, result) {
            res.send("Record added!");
        });
    }
};
