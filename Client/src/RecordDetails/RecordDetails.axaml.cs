using System;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class RecordDetails : UserControl
{
    public string ExitButtonText {get;set;} = "🗙";
	
    public RecordDetails()
    {
        DataContext = this;
        InitializeComponent();
    }

    public RecordDetails(ClientRecord record)
	{
        DataContext = this;
        InitializeComponent();
        NameField.Content = record.RiderName;
        AgeField.Content = record.RiderAge;
        ExperienceField.Content = record.RiderExperience;
        SkiPowerField.Content = record.SkiPower;
        SkiSeatsField.Content = record.SkiSeats;
        SkiPriceField.Content = record.SkiPrice;
        SkiAgeField.Content = record.SkiAge;
        ExcessField.Content = record.Excess;

	}

	void CloseDetails(object s, RoutedEventArgs e)
	{
		IsVisible = false;
	}
}