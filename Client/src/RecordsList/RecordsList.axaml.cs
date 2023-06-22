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

		LoadRecords();
	}

	void LoadRecords()
	{

	}

	void AddRecord(ClientRecord record)
	{
		// RecordsListBox.Items.Add();
	}
}