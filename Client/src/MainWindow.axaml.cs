using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();

		InputForm.TotalUpdated += UpdateTotal;
	}

	void UpdateTotal(int newTotal)
	{
		TotalLabel.Text = newTotal.ToString();
	}

	async void SubmitRecord(object s, RoutedEventArgs e)
	{
		InputForm.IsEnabled = false;
		var success = await NetworkClient.AddRecord(InputForm.CurrentRecord);
		Console.WriteLine(success);
		InputForm.IsEnabled = true;
	}
}