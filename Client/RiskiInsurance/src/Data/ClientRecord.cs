using System;
using System.Text.Json;

namespace RiskiInsurance;

public struct ClientRecord
{
	public string ID = "";
    public int TimeStampUnix;

	public string RiderName = "";
	public byte RiderAge; // Clamp between 16 and 60
	public byte RiderExperience; // Clamp between 0 and 5
	public byte SkiPower; // Must be under 200
	public byte SkiSeats; // 1, 2, or 3
	public int SkiPrice;
	public byte SkiAge;
	public short Excess;

	public int Total;

    public ClientRecord()
	{
		if (ID == "")
			ID = Guid.NewGuid().ToString();
		TimeStampUnix = DateTimeToUnix(DateTime.UtcNow);
    }

	public int CalculateTotal()
	{
		// Insurance total algorithm
		// SUPER SECRET, DO NOT STEAL

		// The basic ‘starter’ quote should be $30
		decimal price = 30;
		// This value should be multiplied by 10 minus the number of years’ experience the rider has (e.g. 2 years’
		// experience, the multiplier would be 10 - 2 = 8.)
		price *= 10 - RiderExperience;

		// If the Jet Ski has 2 seats, add $75 to the quote, for 3 seats, add $90. (No extra for 1 seat)
		if (SkiSeats == 2) { price += 75; }
		if (SkiSeats == 3) { price += 90; }

		// Add 10% for every full $5000 the Jet Ski cost to buy when new. e.g. an $11,000 Jet Ski would add 20%, a $20,000
		// jet Ski would add 40%, and a $4,999 Jet Ski would not incur any additional cost.
		price += (decimal)(0.1 * (int)(SkiPrice / 5000.0)) * price;

		//  The quote so far should then be adjusted according to the following table:
		price *= (decimal)AgeMultiplier(SkiAge);

		// Riski would like to add between $0 and $300 extra onto the quote, depending on the power of the Jet Ski. They
		// would like you to suggest a way of doing this based on your analysis of the data provided.
		// [TODO]

		// Riski would like to allow a discount of up to 25% based on the age of the rider. Again, they would like you to come
		// up with this adjustment, with reasons, based on the provided data.
		// [TODO]

		// Finally, Riski would like you to apply a reasonable adjustment to the quote based on the customers selection of a
		// $100, $300 or $500 excess.
		price += Excess;

		price = Math.Round(price);
		Total = (int)price;
		
		return (int)price;
	}

	double AgeMultiplier(byte age)
	{
		if      (age == 0)             return 1.25;
		else if (age == 1)             return 1.10;
		else if (age >= 2 && age <= 3) return 1.00;
		else if (age >= 4 && age <= 6) return 0.90;
		else if (age >= 7)             return 0.80;
		                               return 1.00;
	}

	/// <summary>
	/// Returns the Unix Timestamp of the given DateTime
	/// </summary>
	/// <param name="dt"></param>
	private int DateTimeToUnix(DateTime dt)
	{
		return (int)((DateTimeOffset)dt).ToUnixTimeSeconds();
    }

	/// <summary>
	/// Returns the DateTime that represents the time the Record was created
	/// </summary>
	/// <returns></returns>
    public DateTime GetTimeStampDateTime()
    {
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dateTime = dateTime.AddSeconds(TimeStampUnix).ToLocalTime();
        return dateTime;
    }
}