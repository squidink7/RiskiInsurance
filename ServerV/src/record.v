pub struct Record {
pub:
	id string           [json: 'ID']
	timestamp int       [json: 'TimeStampUnix']

	rider_name string   [json: 'RiderName']
	rider_age u8        [json: 'RiderAge']
	rider_experience u8 [json: 'RiderExperience']
	ski_power u8        [json: 'SkiPower']
	ski_seats u8        [json: 'SkiSeats']
	ski_price int       [json: 'SkiPrice']
	ski_age u8          [json: 'SkiAge']
	excess i16          [json: 'Excess']

	total int           [json: 'Total']
}