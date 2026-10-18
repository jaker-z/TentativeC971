using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;

namespace TentativeC971;

public partial class TermPopup : Popup<Term>
{
	private Term thisTerm = new Term();
	public TermPopup()
	{
		InitializeComponent();
        TermLabel.Text = "SixSeven";
    }

	public TermPopup(Term term)
	{
		InitializeComponent();
		thisTerm = term;
		TermLabel.Text = thisTerm.Name;
		TermName.Placeholder = thisTerm.Name;
		StartDatePicker.Date = thisTerm.StartDate.ToDateTime(TimeOnly.MinValue);
		EndDatePicker.Date = thisTerm.EndDate.ToDateTime(TimeOnly.MinValue);
    }

	private async void OnButtonClicked(object sender, EventArgs e)
	{
		string name = TermName.Text;
		DateTime? startDatePickerDate = StartDatePicker.Date;
		//DateTime start = startDatePickerDate ?? DateTime.Now;
		DateOnly start = DateOnly.FromDateTime(startDatePickerDate ?? DateTime.Now);
		DateTime? endDatePickerDate = EndDatePicker.Date;
        //DateTime end = endDatePickerDate ?? DateTime.Now;
        DateOnly end = DateOnly.FromDateTime(endDatePickerDate ?? DateTime.Now);

        thisTerm = new Term()
		{
			Name = name,
			StartDate = start,
			EndDate = end
		};

		await CloseAsync(thisTerm);
    }

}