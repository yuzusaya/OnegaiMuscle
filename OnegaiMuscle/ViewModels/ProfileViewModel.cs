﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OnegaiMuscle.Models;

namespace OnegaiMuscle.ViewModels
{
    public class ProfileViewModel
    {
        public ObservableCollection<UserProfile> UserProfiles { get; set; } = new();
        public UserProfile CurrentUserProfile { get; set; } = new();
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

        public ICommand GetProfiles => new Command(async () =>
        {
            var profiles = await App.Database.GetProfilesAsync();
            UserProfiles.Clear();
            foreach (var userProfile in UserProfiles)
            {
                UserProfiles.Add(userProfile);
            }
        });

        public ICommand SaveProfileCommand => new Command(async () =>
        {
            if (string.IsNullOrWhiteSpace(CurrentUserProfile.ContactNumber) ||
                string.IsNullOrWhiteSpace(CurrentUserProfile.Name) ||
                string.IsNullOrWhiteSpace(CurrentUserProfile.Email) ||
                string.IsNullOrWhiteSpace(CurrentUserProfile.StudentId))
            {
                await Shell.Current.DisplayAlert("Warning", "Fill the information la sohai", "Sorry I fill now");
                return;
            }

            await App.Database.SaveProfileAsync(CurrentUserProfile);
            await Shell.Current.GoToAsync("..");
        });
    }
}
