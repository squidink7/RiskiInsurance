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
		UpdateRecordListGUI();
	}

	void UpdateRecordListGUI()
	{
		if (SortTypeComboBox == null || ReverseSortButton == null || RecordsListBox == null) return;

		SortingDirection sortingDirection = ReverseSortButton.IsChecked??false ? SortingDirection.Ascending : SortingDirection.Descending;
		SortingMode sortingMode = (SortingMode)SortTypeComboBox.SelectedIndex;

		Records = SortRecords(sortingMode, sortingDirection, Records);

		RecordsListBox.Children.Clear();
		RecordsListBox.Children.AddRange(Records.Select((record) => {
			var item = new RecordItem(record);
			item.DetailsClicked += () => ShowDetails(record);
			return item;
		}));
	}

	void SortTypeUpdated(object sender, SelectionChangedEventArgs e) => UpdateRecordListGUI();
	void SortDirectionUpdated(object sender, RoutedEventArgs e) => UpdateRecordListGUI();

    AvaloniaList<ClientRecord> SortRecords(SortingMode sortType, SortingDirection sortDirection, AvaloniaList<ClientRecord> records)
	{
		ClientRecord[] tempArr = records.ToArray<ClientRecord>();
        switch (sortType)
		{
			case SortingMode.Date:
				tempArr = tempArr.OrderByDescending(Record => Record.GetTimeStampDateTime()).ToArray<ClientRecord>();
				break;
			case SortingMode.Total:
				tempArr = tempArr.OrderByDescending(Record => Record.Total).ToArray<ClientRecord>();
				break;
            case SortingMode.RiderAge:
                tempArr = tempArr.OrderByDescending(Record => Record.RiderAge).ToArray<ClientRecord>();
                break;
            case SortingMode.RiderExperience:
                tempArr = tempArr.OrderByDescending(Record => Record.RiderExperience).ToArray<ClientRecord>();
                break;
            case SortingMode.SkiPower:
                tempArr = tempArr.OrderByDescending(Record => Record.SkiPower).ToArray<ClientRecord>();
                break;
            case SortingMode.SkiSeats:
                tempArr = tempArr.OrderByDescending(Record => Record.SkiSeats).ToArray<ClientRecord>();
                break;
            case SortingMode.SkiPrice:
                tempArr = tempArr.OrderByDescending(Record => Record.SkiPrice).ToArray<ClientRecord>();
                break;
            case SortingMode.SkiAge:
                tempArr.OrderByDescending(Record => Record.SkiAge).ToArray<ClientRecord>();
                break;
            case SortingMode.Excess:
                tempArr = tempArr.OrderByDescending(Record => Record.Excess).ToArray<ClientRecord>();
                break;
        }
		//Array is currently in descending order, if the list should be ascending then reverse it now
        if (sortDirection == SortingDirection.Ascending)
		{
			tempArr = tempArr.Reverse<ClientRecord>().ToArray<ClientRecord>();
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
		Excess
	}
	
	void BackClicked(object s, RoutedEventArgs e)
	{
		AppView.RemovePage();
	}
}