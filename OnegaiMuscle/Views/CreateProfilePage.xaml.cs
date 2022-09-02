using OnegaiMuscle.ViewModels;

namespace OnegaiMuscle;

public partial class CreateProfilePage : ContentPage
{
	public CreateProfilePage(SaveProfileViewModel vm)
	{
		InitializeComponent();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior()
        {
            TextOverride = "Back"
        });
        BindingContext = vm;
    }
}