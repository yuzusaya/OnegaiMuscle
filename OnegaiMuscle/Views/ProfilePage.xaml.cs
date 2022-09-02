using OnegaiMuscle.ViewModels;
namespace OnegaiMuscle;

public partial class ProfilePage : ContentPage
{
    public ProfilePage(ProfileViewModel vm)
	{
		InitializeComponent();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior()
        {
            TextOverride = "Back"
        });
        BindingContext = vm;
    }
}