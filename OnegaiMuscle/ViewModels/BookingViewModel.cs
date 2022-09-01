using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace OnegaiMuscle.ViewModels;

public partial class BookingViewModel:ObservableObject
{
    [RelayCommand]
    async Task Profile(string s)
    {
        await Shell.Current.GoToAsync(nameof(ProfilePage));
    }
}
