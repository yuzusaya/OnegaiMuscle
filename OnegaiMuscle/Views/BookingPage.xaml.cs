using OnegaiMuscle.ViewModels;

namespace OnegaiMuscle;

public partial class BookingPage : ContentPage
{
	public BookingPage(BookingViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}