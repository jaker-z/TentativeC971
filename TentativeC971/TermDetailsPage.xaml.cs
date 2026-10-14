namespace TentativeC971;

public partial class TermDetailsPage : ContentPage
{
	public TermDetailsPage(TermDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}