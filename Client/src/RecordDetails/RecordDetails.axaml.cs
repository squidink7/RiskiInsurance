using System;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class RecordDetails : UserControl
{
    public string ExitButtonText
    {
        get;
        set;
    } = "🗙";
    public RecordDetails()
    {
        DataContext = this;
        InitializeComponent();
    }
    public RecordDetails(ClientRecord record)
	{
        DataContext = this;
        InitializeComponent();
	}
}