sudo mysql --execute="
CREATE DATABASE RiskiInsurance;

USE RiskiInsurance;

CREATE TABLE ClientRecords(ID varchar(255), TimeStampUnix int, RiderName varchar(255), RiderAge smallint, RiderExperience smallint, SkiPower smallint, SkiSeats smallint, SkiPrice int, SkiAge smallint, Excess int, Total int);

CREATE USER 'server'@'localhost' IDENTIFIED BY 'RiskiInsurance';

GRANT ALL PRIVILEGES ON *.* TO 'server'@'localhost' WITH GRANT OPTION;

FLUSH PRIVILEGES;
"
echo "DB set up"
sudo mysql --database="RiskiInsurance"