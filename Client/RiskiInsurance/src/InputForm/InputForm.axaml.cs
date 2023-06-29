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
			RiderAge = Convert.ToByte(Math.Clamp(RiderAgeBox.Value ?? 0, 0, byte.MaxValue)),
			RiderExperience = Convert.ToByte(Math.Clamp(RiderExperienceBox.Value ?? 0, 0, byte.MaxValue)),
			SkiAge = Convert.ToByte(Math.Clamp(SkiAgeBox.Value ?? 0, 0, byte.MaxValue)),
			SkiPower = Convert.ToByte(Math.Clamp(SkiPowerBox.Value ?? 0, 0, byte.MaxValue)),
			SkiPrice = Convert.ToInt32(Math.Clamp(SkiPriceBox.Value ?? 0, 0, int.MaxValue)),
			SkiSeats = Convert.ToByte(Math.Clamp(SkiSeatsBox.Value ?? 0, 0, byte.MaxValue)),
			Excess = Convert.ToInt16(Math.Clamp(ExcessBox.Value ?? 0, 0, short.MaxValue)),
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
		await NetworkClient.AddRecord(CurrentRecord);
		IsEnabled = true;
	}

	void BackClicked(object s, RoutedEventArgs e)
	{
		AppView.RemovePage();
	}
}