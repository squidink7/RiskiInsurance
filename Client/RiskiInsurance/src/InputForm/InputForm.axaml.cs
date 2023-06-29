using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class InputForm : UserControl, IPage
{
	public ClientRecord CurrentRecord;
	
	public InputForm()
	{
		InitializeComponent();

		ClearInput();
	}

	void TextFieldUpdated(object s, TextChangedEventArgs e) => CalculateTotal();
	void NumberFieldUpdated(object s, NumericUpDownValueChangedEventArgs e) => CalculateTotal();

	void CalculateTotal()
	{
		CurrentRecord = new ClientRecord
		{
			RiderName = RiderNameBox.Text ?? "Unnamed Client",
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

	void ClearInput()
	{
		RiderNameBox.Text = "";
		RiderAgeBox.Value = RiderAgeBox.Minimum;
		RiderExperienceBox.Value = RiderExperienceBox.Minimum;
		SkiAgeBox.Value = SkiAgeBox.Minimum;
		SkiPowerBox.Value = SkiPowerBox.Minimum;
		SkiPriceBox.Value = SkiPriceBox.Minimum;
		SkiSeatsBox.Value = SkiSeatsBox.Minimum;
		ExcessBox.Value = ExcessBox.Minimum;

		CalculateTotal();
	}

	async void SubmitRecord(object s, RoutedEventArgs e)
	{
		IsEnabled = false;
		var success = await NetworkClient.AddRecord(CurrentRecord);
		IsEnabled = true;
	}

	void BackClicked(object s, RoutedEventArgs e)
	{
		AppView.SetPage(Page.HOME);
	}
}