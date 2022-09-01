namespace OnegaiMuscle;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(BookingPage),typeof(BookingPage));
		Routing.RegisterRoute(nameof(ProfilePage),typeof(ProfilePage));
		Routing.RegisterRoute(nameof(CreateProfilePage),typeof(CreateProfilePage));
	}
}
