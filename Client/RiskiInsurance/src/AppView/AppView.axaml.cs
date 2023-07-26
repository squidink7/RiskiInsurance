using System;
using System.Collections.Generic;
using System.Threading;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;

namespace RiskiInsurance;

public partial class AppView : UserControl
{
	static Panel? ViewHolder;

	public AppView()
	{
		InitializeComponent();

		ViewHolder = ViewHolderInstance;

		var networkTimer = new Timer((o) => Dispatcher.UIThread.InvokeAsync(DetectNetwork));
		networkTimer.Change(0, 10000); // Try to sync with server every 10 seconds (if offline)
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		if (e.Key == Key.Escape)
			RemovePage();
	}

	public static void AddPage(Control page)
	{
		if (ViewHolder != null)
		{
			ViewHolder.Children.Add(page);
			if (page is IPage ipage) ipage.Show();
		}
	}

	public static void RemovePage()
	{
		if (ViewHolder != null)
		{
			if (ViewHolder.Children.Count > 1)
			{
				ViewHolder.Children.RemoveAt(ViewHolder.Children.Count - 1);
			}
		}
	}

	async void DetectNetwork()
	{
		if (NetworkClient.Online) return;

		NetworkLabel.Text = "Connecting...";
		NetworkLabelBorder.Background = new SolidColorBrush(new Color(255, 0, 255, 0));
		NetworkLabelBorder.Classes.Add("Visible");

		var online = await NetworkClient.Sync();

		if (online)
		{
			NetworkLabelBorder.Classes.Remove("Visible");
		}
		else
		{
			NetworkLabel.Text = "Offline: Records will not be saved!";
			NetworkLabelBorder.Background = new SolidColorBrush(new Color(255, 255, 0, 0));
		}
	}
}

public enum Page
{
	HOME,
	NEWRECORD,
    VIEWRECORDS
}