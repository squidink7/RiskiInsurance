using System;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class RecordsList : UserControl
{
	public AvaloniaList<ClientRecord> Records = new();
	
	public RecordsList()
	{
		InitializeComponent();
	}

	public void AddRecord(ClientRecord record)
	{
		// RecordsListBox.Items.Add();
	}
}