namespace OnegaiMuscle;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(BookingPage),typeof(BookingPage));
	}
}
