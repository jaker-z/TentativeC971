namespace TentativeC971;

public partial class CourseDetailsPage : ContentPage
{
	public CourseDetailsPage(CourseDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}