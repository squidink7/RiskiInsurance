using System.Text.Json;

struct ClientRecord
{
	public byte RiderAge;
	public byte RiderExperience; // Clamp between 0 and 5
	public byte SkiPower; // Must be under 200
	public byte SkiSeats; // 1, 2, or 3
	public int SkiPrice;
	public byte SkiAge;
	public short Excess;

	public int CalculateTotal()
	{
		
	}
}