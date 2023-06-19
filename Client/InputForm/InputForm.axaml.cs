using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class InputForm : UserControl
{
	// Total updated event
	public delegate void TotalUpdatedEventHandler(int newTotal);
	public event TotalUpdatedEventHandler? TotalUpdated;

	public ClientRecord CurrentRecord;
	
	public InputForm()
	{
		InitializeComponent();

		CalculateTotal();
	}

	void TextFieldUpdated(object s, TextChangedEventArgs e) => CalculateTotal();
	void NumberFieldUpdated(object s, NumericUpDownValueChangedEventArgs e) => CalculateTotal();

	void CalculateTotal()
	{
		// TODO: actual math
		// int total = (int)(TestBox.Value??0);
		// TotalUpdated?.Invoke(total);

		CurrentRecord.RiderAge = (byte)(RiderAgeBox.Value??0);
	}
}