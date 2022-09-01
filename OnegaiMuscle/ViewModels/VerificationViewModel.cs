using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace OnegaiMuscle.ViewModels;

public partial class VerificationViewModel:ObservableObject
{
    [RelayCommand]
    async Task Verify(string s)
    {
        await Shell.Current.GoToAsync(nameof(BookingPage));
    }
}
