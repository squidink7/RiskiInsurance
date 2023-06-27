using System;
using System.Linq;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RiskiInsurance;

public partial class RecordsList : UserControl
{
	public AvaloniaList<ClientRecord> Records = new();
	public RecordsList()
	{
		InitializeComponent();
		LoadRecords();
		MainWindow.ReloadRecords += new EventHandler((sender, e) =>
		{
			LoadRecords();
		});
	}

	async void LoadRecords()
	{
		Records = await NetworkClient.GetRecords();
		RecordsListBox.Children.Clear();
		RecordsListBox.Children.AddRange(Records.Select(record => new RecordItem(record)));
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

    void AddRecord(ClientRecord record)
	{
		// RecordsListBox.Items.Add();
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
}