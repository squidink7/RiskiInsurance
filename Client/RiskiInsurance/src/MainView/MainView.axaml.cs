using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class MainView : UserControl, IPage
{	
	public MainView()
	{
		InitializeComponent();
	}

	void OpenAddRecord(object sender, RoutedEventArgs e)
	{
		AppView.AddPage(new InputForm());
	}
    void OpenViewRecords(object sender, RoutedEventArgs e)
    {
        AppView.AddPage(new RecordsList());
    }
}