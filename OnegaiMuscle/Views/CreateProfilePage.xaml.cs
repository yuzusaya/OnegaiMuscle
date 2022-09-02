namespace OnegaiMuscle;

public partial class CreateProfilePage : ContentPage
{
	public CreateProfilePage()
	{
		InitializeComponent();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior()
        {
            TextOverride = "Back"
        });
    }
}