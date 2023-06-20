using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class InputForm : UserControl
{
	// Total updated event
	public delegate void TotalUpdatedEventHandler(int newTotal);
	public event TotalUpdatedEventHandler? TotalUpdated;

	public ClientRecord CurrentRecord;
	
	public InputForm()
	{
		InitializeComponent();

		CalculateTotal();
	}

	void TextFieldUpdated(object s, TextChangedEventArgs e) => CalculateTotal();
	void NumberFieldUpdated(object s, NumericUpDownValueChangedEventArgs e) => CalculateTotal();

	void CalculateTotal()
	{
		CurrentRecord.RiderAge = (byte)(RiderAgeBox.Value ?? 0);
		CurrentRecord.RiderExperience = (byte)(RiderExperienceBox.Value ?? 0);
		CurrentRecord.SkiAge = (byte)(SkiAgeBox.Value ?? 0);
		CurrentRecord.SkiPower = (byte)(SkiPowerBox.Value ?? 0);
		CurrentRecord.SkiPrice = (int)(SkiPriceBox.Value ?? 0);
		CurrentRecord.SkiSeats = (byte)(SkiSeatsBox.Value ?? 0);
		CurrentRecord.Excess = (byte)(ExcessBox.Value ?? 0);

		CurrentRecord.TimeStamp = DateTime.Now;

		TotalUpdated?.Invoke(CurrentRecord.CalculateTotal());
	}
}