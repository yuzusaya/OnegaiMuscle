namespace OnegaiMuscle;

public partial class App : Application
{
    static MuscleDatabase database;

    // Create the database connection as a singleton.
    public static MuscleDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new MuscleDatabase();
            }
            return database;
        }
    }

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
        if (Preferences.Get("LoginSuccess", false))
        {
            Shell.Current.GoToAsync($"//{nameof(BookingPage)}");
        }
	}
}
