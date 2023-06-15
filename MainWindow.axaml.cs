using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

	void SayHello(object s, RoutedEventArgs e)
	{
		var newText = "";

		if (String.IsNullOrEmpty(NameBox.Text))
		{
			newText = "Please type your name";
		}
		else if (NameBox.Text.ToLower() == "your name")
		{
			newText = "Okay smartass";
		}
		else
		{
			newText = $"Hello, {NameBox.Text}!";
		}

		ResultLabel.Text = newText;
	}
}