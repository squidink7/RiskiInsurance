using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class MainView : UserControl
{	
	public MainView()
	{
		InitializeComponent();
	}

	void OpenAddRecord(object sender, RoutedEventArgs e)
	{
		MainWindow.SetPage(Page.NEWRECORD);
	}
    void OpenViewRecords(object sender, RoutedEventArgs e)
    {
        MainWindow.SetPage(Page.VIEWRECORDS);
    }
}