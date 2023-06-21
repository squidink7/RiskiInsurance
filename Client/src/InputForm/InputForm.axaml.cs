using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class InputForm : UserControl
{
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
		CurrentRecord = new ClientRecord
		{
			RiderAge = (byte)(RiderAgeBox.Value ?? 0),
			RiderExperience = (byte)(RiderExperienceBox.Value ?? 0),
			SkiAge = (byte)(SkiAgeBox.Value ?? 0),
			SkiPower = (byte)(SkiPowerBox.Value ?? 0),
			SkiPrice = (int)(SkiPriceBox.Value ?? 0),
			SkiSeats = (byte)(SkiSeatsBox.Value ?? 0),
			Excess = (short)(ExcessBox.Value ?? 0),
		};

		TotalLabel.Text = CurrentRecord.CalculateTotal().ToString();
	}

	async void SubmitRecord(object s, RoutedEventArgs e)
	{
		IsEnabled = false;
		var success = await NetworkClient.AddRecord(CurrentRecord);
		Console.WriteLine(success);
		IsEnabled = true;
	}
}