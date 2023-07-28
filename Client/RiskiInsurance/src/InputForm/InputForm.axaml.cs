using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class InputForm : UserControl, IPage
{
	public ClientRecord CurrentRecord = new();

	bool Loading = false;
	
	public InputForm()
	{
		InitializeComponent();

		ClearInput();
	}

	public InputForm(ClientRecord record)
	{
		CurrentRecord = record;

		InitializeComponent();

		Loading = true;

		RiderNameBox.Text = CurrentRecord.RiderName;
		RiderAgeBox.Value = CurrentRecord.RiderAge;
		RiderExperienceBox.Value = CurrentRecord.RiderExperience;
		SkiAgeBox.Value = CurrentRecord.SkiAge;
		SkiPowerBox.Value = CurrentRecord.SkiPower;
		SkiPriceBox.Value = CurrentRecord.SkiPower;
		SkiSeatsBox.Value = CurrentRecord.SkiSeats;
		if (CurrentRecord.Excess == 100)
			ExcessBox.SelectedIndex = 0;
		if (CurrentRecord.Excess == 300)
			ExcessBox.SelectedIndex = 1;
		if (CurrentRecord.Excess == 500)
			ExcessBox.SelectedIndex = 2;

		Loading = false;

		CalculateTotal();
	}

	void TextFieldUpdated(object s, TextChangedEventArgs e) => CalculateTotal();
	void NumberFieldUpdated(object s, NumericUpDownValueChangedEventArgs e) => CalculateTotal();
	void ComboFieldUpdated(object s, SelectionChangedEventArgs e) => CalculateTotal();

	void CalculateTotal()
	{
		if (Loading) return;

		CurrentRecord = new ClientRecord
		{
			ID = CurrentRecord.ID,
			RiderName = RiderNameBox.Text ?? "Unnamed Client",
			RiderAge = Convert.ToByte(Math.Clamp(RiderAgeBox.Value ?? 0, 0, byte.MaxValue)),
			RiderExperience = Convert.ToByte(Math.Clamp(RiderExperienceBox.Value ?? 0, 0, byte.MaxValue)),
			SkiAge = Convert.ToByte(Math.Clamp(SkiAgeBox.Value ?? 0, 0, byte.MaxValue)),
			SkiPower = Convert.ToInt16(Math.Clamp(SkiPowerBox.Value ?? 0, 0, Int16.MaxValue)),
			SkiPrice = Convert.ToInt32(Math.Clamp(SkiPriceBox.Value ?? 0, 0, int.MaxValue)),
			SkiSeats = Convert.ToByte(Math.Clamp(SkiSeatsBox.Value ?? 0, 0, byte.MaxValue)),
			Excess = Convert.ToInt16(Math.Clamp(Convert.ToInt16(((ComboBoxItem?)ExcessBox?.SelectedItem)?.Content), (short)0, short.MaxValue)),
		};

		TotalLabel.Text = CurrentRecord.CalculateTotal().ToString();
	}

	void ClearInput()
	{
		Loading = true;
		RiderNameBox.Text = "";
		RiderAgeBox.Value = RiderAgeBox.Minimum;
		RiderExperienceBox.Value = RiderExperienceBox.Minimum;
		SkiAgeBox.Value = SkiAgeBox.Minimum;
		SkiPowerBox.Value = SkiPowerBox.Minimum;
		SkiPriceBox.Value = SkiPriceBox.Minimum;
		SkiSeatsBox.Value = SkiSeatsBox.Minimum;
		ExcessBox.SelectedIndex = 0;
		Loading = false;
		CalculateTotal();
	}

	async void SubmitRecord(object s, RoutedEventArgs e)
	{
		IsEnabled = false;
		var success = await NetworkClient.AddRecord(CurrentRecord);
		IsEnabled = true;
		if (success)
		{
			ClearInput();
		}
		else
		{
			
		}

	}

	void BackClicked(object s, RoutedEventArgs e)
	{
		AppView.RemovePage();
	}
}