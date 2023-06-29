using System;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class RecordDetails : UserControl, IPage
{
	ClientRecord CurrentRecord;
	public event Action? RecordUpdated;

	public RecordDetails()
	{
		DataContext = this;
		InitializeComponent();
	}

	public RecordDetails(ClientRecord record)
	{
		DataContext = this;
		InitializeComponent();
		SetRecord(record);
	}

	public void SetRecord(ClientRecord record)
	{
		CurrentRecord = record;

		NameField.Text = record.RiderName.ToString();
        AgeField.Text = record.RiderAge.ToString();
        ExperienceField.Text = record.RiderExperience.ToString();
        SkiPowerField.Text = record.SkiPower.ToString();
        SkiSeatsField.Text = record.SkiSeats.ToString();
        SkiPriceField.Text = record.SkiPrice.ToString();
        SkiAgeField.Text = record.SkiAge.ToString();
        ExcessField.Text = record.Excess.ToString();
	}

	void CloseDetails(object s, RoutedEventArgs e)
	{
		IsVisible = false;
	}

	void EditRecord(object s, RoutedEventArgs e)
	{
		RecordUpdated?.Invoke();
	}

	async void DeleteRecord(object s, RoutedEventArgs e)
	{
		IsEnabled = false;
		await NetworkClient.RemoveRecord(CurrentRecord.ID);
		RecordUpdated?.Invoke();
		IsVisible = false;
		IsEnabled = true;
	}
}