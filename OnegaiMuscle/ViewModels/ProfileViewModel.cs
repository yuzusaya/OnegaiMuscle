using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using OnegaiMuscle.Models;

namespace OnegaiMuscle.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        public ObservableCollection<UserProfile> UserProfiles { get; } = new();

        [RelayCommand(AllowConcurrentExecutions = false)]
        async Task DeleteProfile(UserProfile record)
        {
            var delete = await Shell.Current.DisplayAlert("Confirmation",
                "Are you sure you want to delete this profile?", "OK", "Cancel");
            if (delete)
            {
                await App.Database.DeleteProfileAsync(record);
                UserProfiles.Remove(record);
                if (Preferences.Get("LastSelectedUserId", 0) == record.Id)
                {
                    var profiles = await App.Database.GetProfilesAsync();
                    var nextProfileId = (profiles.FirstOrDefault()?.Id) ?? 0;
                    Preferences.Set("LastSelectedUserId", nextProfileId);
                    MessagingCenter.Send(this, "ProfileSelected", nextProfileId);
                }
            }
        }

        [RelayCommand(AllowConcurrentExecutions = false)]
        async Task UpdateProfile(UserProfile record)
        {
            await Shell.Current.GoToAsync($"{nameof(CreateProfilePage)}",
                animate: true,
                new Dictionary<string, object>()
                {
                        {"Id",record.Id}
                });
        }

        [RelayCommand(AllowConcurrentExecutions = false)]
        async Task CreateProfile()
        {
            await Shell.Current.GoToAsync(nameof(CreateProfilePage));
        }

        [RelayCommand(AllowConcurrentExecutions = false)]
        async Task SelectProfile(UserProfile record)
        {
            if (await Shell.Current.DisplayAlert("Confirmation", $"Are you sure you want set {record.Name} as profile?", "Yes", "No"))
            {
                MessagingCenter.Send(this, "ProfileSelected", record.Id);
                await Shell.Current.GoToAsync("..");
            }
        }

        [RelayCommand]
        async Task Appearing()
        {
            var profiles = await App.Database.GetProfilesAsync();
            if (Preferences.Get("LastSelectedUserId", 0) == 0 && profiles.Any())
            {
                var nextProfileId = (profiles.FirstOrDefault()?.Id) ?? 0;
                Preferences.Set("LastSelectedUserId", nextProfileId);
                MessagingCenter.Send(this, "ProfileSelected", nextProfileId);
            }
            UserProfiles.Clear();
            foreach (var userProfile in profiles)
            {
                UserProfiles.Add(userProfile);
            }
        }
    }
}
