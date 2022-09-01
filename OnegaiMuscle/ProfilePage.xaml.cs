using OnegaiMuscle.ViewModels;
namespace OnegaiMuscle;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
    }
    public ProfilePage(ProfileViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}