using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class AppView : UserControl
{
	static Carousel? ViewHolder;

	public AppView()
	{
		InitializeComponent();

		ViewHolder = ViewHolderInstance;
	}

	public static void SetPage(Page page)
	{
		if (ViewHolder != null)
		{
			ViewHolder.SelectedIndex = (int)page;

			if (ViewHolder.SelectedItem is IPage currentPage)
			{
				currentPage.Show();
			}
		}
	}
}

public enum Page
{
	HOME,
	NEWRECORD,
    VIEWRECORDS
}