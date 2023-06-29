using System;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class RecordDetails : UserControl, IPage
{
	// public
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
	}

	void DeleteRecord(object s, RoutedEventArgs e)
	{
		IsVisible = false;
	}
}