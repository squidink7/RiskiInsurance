using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class MainWindow : Window
{
	static Carousel? ViewHolder;
	
	public MainWindow()
	{
		InitializeComponent();

		ViewHolder = ViewHolderInstance;
	}

	public static void SetPage(Page page)
	{
		if (ViewHolder != null)
			ViewHolder.SelectedIndex = (int)page;
	}
}

public enum Page
{
	HOME,
	NEWRECORD
}