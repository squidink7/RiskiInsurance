using System;
using System.Linq;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class RecordsList : UserControl, IPage
{
	public AvaloniaList<ClientRecord> Records = new();
	public RecordsList()
	{
		InitializeComponent();
		LoadRecords();
	}

	public void Show() => LoadRecords();

	async void LoadRecords()
	{
		Records = await NetworkClient.GetRecords();
		RecordsListBox.Children.Clear();
		RecordsListBox.Children.AddRange(Records.Select((record) => {
			var item = new RecordItem(record);
			item.DetailsClicked += () => ShowDetails(record);
			return item;
		}));
	}

	AvaloniaList<ClientRecord> SortRecords(SortingMode sortType, SortingDirection sortDirection, AvaloniaList<ClientRecord> records)
	{
		ClientRecord[] tempArr = records.ToArray<ClientRecord>();
		switch (sortType)
		{
			case SortingMode.Date:
				tempArr.OrderByDescending(Record => Record.GetTimeStampDateTime());
				break;
			case SortingMode.Total:
				tempArr.OrderByDescending(Record => Record.Total);
				break;
            case SortingMode.RiderAge:
                tempArr.OrderByDescending(Record => Record.RiderAge);
                break;
            case SortingMode.RiderExperience:
                tempArr.OrderByDescending(Record => Record.RiderExperience);
                break;
            case SortingMode.SkiPower:
                tempArr.OrderByDescending(Record => Record.SkiPower);
                break;
            case SortingMode.SkiSeats:
                tempArr.OrderByDescending(Record => Record.SkiSeats);
                break;
            case SortingMode.SkiPrice:
                tempArr.OrderByDescending(Record => Record.SkiPrice);
                break;
            case SortingMode.SkiAge:
                tempArr.OrderByDescending(Record => Record.SkiAge);
                break;
            case SortingMode.Excees:
                tempArr.OrderByDescending(Record => Record.Excess);
                break;
        }
		//Array is currently in descending order, if the list should be ascending then reverse it now
		if (sortDirection == SortingDirection.Ascending)
		{
			tempArr.Reverse<ClientRecord>();
		}
		return new AvaloniaList<ClientRecord>(tempArr);
	}

    void ShowDetails(ClientRecord record)
	{
		DetailsView.IsVisible = true;
		DetailsView.SetRecord(record);
	}

	public enum SortingDirection
	{
		Ascending,
		Descending
	}

	public enum SortingMode
	{
		Date,
		Total,
		RiderAge,
		RiderExperience,
		SkiPower,
		SkiSeats,
		SkiPrice,
		SkiAge,
		Excees
	}
	
	void BackClicked(object s, RoutedEventArgs e)
	{
		AppView.RemovePage();
	}
}