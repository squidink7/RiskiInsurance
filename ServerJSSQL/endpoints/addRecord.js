const fs = require('fs');
const {con} = require('../sqlConnect.js');

module.exports = {
    method: 'POST',
    path: '/addRecord',
    handler: function(req, res) {
        let record = JSON.parse(req.body);
        //First Check if record already exists
        let sql = `SELECT 1 FROM ClientRecords WHERE ID = "${record.ID}";`
        con.query(sql, function(err, result) {
            if (result.length > 0) {
                //Record Already Exists, Update it
                sql = `
                    UPDATE ClientRecords
                    SET
                        TimeStampUnix = "${record.TimeStampUnix}",
                        RiderName = "${record.RiderName}",
                        RiderAge = "${record.RiderAge}",
                        RiderExperience = "${record.RiderExperience}",
                        SkiPower = "${record.SkiPower}",
                        SkiSeats = "${record.SkiSeats}",
                        SkiPrice = "${record.SkiPrice}",
                        SkiAge = "${record.SkiAge}",
                        Excess = "${record.Excess}",
                        Total = "${record.Total}"
                    WHERE
                        ID = "${record.ID}";
                `
            }else{
                //Record Does Not Exist, Create it
                sql = `
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
            }
            console.log(sql);
            con.query(sql, function(err, result) {
                res.send('Record added!');
            });
        });
    }
};
