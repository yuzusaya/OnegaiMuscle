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
        public ObservableCollection<UserProfile> UserProfiles { get; set; } = new();
        public ICommand DeleteProfileCommand=>new Command<UserProfile>(async (record)=>
        {
            var delete = await Shell.Current.DisplayAlert("Confirmation",
                "Are you sure you want to delete this profile?", "OK", "Cancel");
            if (delete)
            {
                await App.Database.DeleteProfileAsync(record);
                UserProfiles.Remove(record);
            }
        });

        public ICommand GoToUpdateProfilePageCommand => new Command<UserProfile>(async (record) =>
        {
            await Shell.Current.Navigation.PushAsync(new Page()
            {
                BindingContext = this
            });
        });

        public ICommand SelectProfileCommand => new Command<UserProfile>(async (record) =>
        {
            MessagingCenter.Send(this,"ProfileSelected",record.Id);
            await Shell.Current.Navigation.PopAsync();
        });

        [RelayCommand]
        async Task CreateProfile(string s)
        {
            await Shell.Current.GoToAsync(nameof(CreateProfilePage));
        }

        [RelayCommand]
        async Task Appearing()
        {
            var profiles = await App.Database.GetProfilesAsync();
            UserProfiles.Clear();
            foreach (var userProfile in profiles)
            {
                UserProfiles.Add(userProfile);
            }
        }
    }
}
