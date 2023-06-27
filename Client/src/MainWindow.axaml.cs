using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class MainWindow : Window
{
	static Carousel? ViewHolder;

	public static event EventHandler ReloadRecords;

	public MainWindow()
	{
		InitializeComponent();

		ViewHolder = ViewHolderInstance;
	}

	public static void SetPage(Page page)
	{
		if (ViewHolder != null)
		{
			if (page == Page.VIEWRECORDS)
			{
				MainWindow.ReloadRecords.Invoke(new object(), new EventArgs());
			}
			ViewHolder.SelectedIndex = (int)page;
		}
	}
}

public enum Page
{
	HOME,
	NEWRECORD,
    VIEWRECORDS
}