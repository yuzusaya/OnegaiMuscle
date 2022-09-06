using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OnegaiMuscle.Models;
using OnegaiMuscle.Services;

namespace OnegaiMuscle.ViewModels;

public partial class BookingViewModel : BaseViewModel
{
    public DateTime CurrentTime => DateTime.Now;
    public List<string> SessionList => new()
        {
            "Session 1 (8.00 am - 9.30 am)",
            "Session 2 (9.30 am - 11.00 am)",
            "Session 3 (11.00 am - 12.30 pm)",
            "Session 4 (12.30 pm - 2.00 pm)",
            "Session 5 (2.00 pm - 3.30 pm)",
            "Session 6 (3.30 pm - 5.00 pm)",
            "Session 7 (5.00 pm - 6.00 pm) Strictly For Staff Only"
        };

    [ObservableProperty]
    string _userName = "Anonymous";

    private AlertService _alertService;

    public int SelectedUserProfileId => Preferences.Get("LastSelectedUserId", 0);

    public string SelectedSession { get; set; }

    public BookingViewModel(AlertService alertService)
    {
        _alertService = alertService;
        Task.Run(async () =>
        {
            var profile = await App.Database.GetProfileByIdAsync(Preferences.Get("LastSelectedUserId", 0));
            if (profile != null)
            {
                UserName = profile.Name;
            }
        });
        MessagingCenter.Subscribe<ProfileViewModel, int>(this, "ProfileSelected", async (_, id) =>
        {
            var profile = await App.Database.GetProfileByIdAsync(id);
            if (profile != null)
            {
                UserName = profile.Name;
                Preferences.Set("LastSelectedUserId", id);
            }
        });
        MessagingCenter.Subscribe<SaveProfileViewModel>(this, "NameChanged", async(_) =>
        {
            var profile = await App.Database.GetProfileByIdAsync(Preferences.Get("LastSelectedUserId",0));
            UserName = (profile?.Name)?? "Anonymous";
        });
    }
    [RelayCommand]
    async Task Submit()
    {
        var user = await App.Database.GetProfileByIdAsync(SelectedUserProfileId);
        if (user == null)
        {
            await Shell.Current.DisplayAlert("Warning", "You haven't choose the profile", "Ok");
            return;
        }
        var ans = await Shell.Current.DisplayActionSheet("Choose Session", "Cancel", null, SessionList.ToArray());
        if (!SessionList.Contains(ans))
            return;

        //if (string.IsNullOrWhiteSpace(SelectedSession))
        //{
        //    return;
        //}

        var currentTime = DateTime.Now;
        var lastRecord = await App.Database.GetLastBookingRecord();
        if (lastRecord?.CreatedDate.Date == currentTime.Date)
        {
            if (!await Shell.Current.DisplayAlert("Warning",
                    "You have submitted the form today. Are you sure you want to submit next form?", "Yes", "No"))
                return;
        }
        
        try
        {
            HttpClient httpClient = new HttpClient();
            var url = new Uri($"https://docs.google.com/forms/u/0/d/e/1FAIpQLSdYrqClc4Knm6sFzeUY8ldazQBQteMCv6-d9xWo47V4Ne-K0A/formResponse?entry.135433756={user.Name}&entry.1463710679={user.StudentId}&entry.390244614={user.ContactNumber}&entry.984636927_year={currentTime.Year}&entry.984636927_month={currentTime.Month}&entry.984636927_day={currentTime.Day}&entry.1493146651={ans}&emailAddress={user.Email}");
            //var response = await httpClient.PostAsync("https://docs.google.com/forms/u/0/d/e/1FAIpQLScCOeWb1_DXr2RpNgtn1QyxhOAxll6eZysPHIlysf6HDobGxg/formResponse?entry.366340186=Option 2", null);
            var response = await httpClient.PostAsync(url, null);
            response.EnsureSuccessStatusCode();
            await App.Database.AddBookingRecordAsync(new BookingRecord()
            {
                Name = user.Name,
                ContactNumber = user.ContactNumber,
                CreatedDate = currentTime,
                Email = user.Email,
                StudentId = user.StudentId
            });
            _alertService.ShowToast("Submitted");
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlert("Error", e.Message, "ok");
        }
    }

    [RelayCommand]
    void Appearing()
    {
        OnPropertyChanged(nameof(CurrentTime));
    }

    [RelayCommand]
    async Task Profile()
    {
        await Shell.Current.GoToAsync(nameof(ProfilePage));
    }
}
