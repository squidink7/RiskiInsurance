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
	}

	void ShowDetails(object s, RoutedEventArgs e)
	{

	}
}