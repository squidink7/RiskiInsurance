using System;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class RecordItem : UserControl
{	
	public ClientRecord Record;

	public RecordItem()
	{
		InitializeComponent();
	}
	
	public RecordItem(ClientRecord record)
	{
		InitializeComponent();

		SetRecord(record);
	}

	public void SetRecord(ClientRecord record)
	{
		TitleLabel.Text = record.RiderName;
		TotalLabel.Text = record.Total.ToString();
		DateLabel.Text = record.GetTimeStampDateTime().ToString();
	}

	void ShowDetails(object s, RoutedEventArgs e)
	{
		
	}
}