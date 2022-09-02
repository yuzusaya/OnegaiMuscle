using OnegaiMuscle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace OnegaiMuscle.ViewModels
{
    [QueryProperty("Id", "Id")]
    public partial class SaveProfileViewModel : BaseViewModel
    {
        private int _id;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                if (_id != 0)
                {
                    Task.Run(async () =>
                    {
                        var user = await App.Database.GetProfileByIdAsync(_id);
                        if (user != null)
                        {
                            Name = user.Name;
                            Email = user.Email;
                            StudentId = user.StudentId;
                            ContactNumber = user.ContactNumber;
                        }
                    });
                }
            }
        }

        [ObservableProperty]
        private UserProfile _currentUserProfile = new();

        [ObservableProperty] 
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private string _name;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private string _email;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private string _studentId;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private string _contactNumber;

        public bool CanSave => !string.IsNullOrWhiteSpace(ContactNumber) &&
                                !string.IsNullOrWhiteSpace(Name) &&
                                !string.IsNullOrWhiteSpace(Email) &&
                                !string.IsNullOrWhiteSpace(StudentId);

        [RelayCommand(AllowConcurrentExecutions = false, CanExecute = nameof(CanSave))]
        async Task Save()
        {
            CurrentUserProfile.Id = Id;
            CurrentUserProfile.Name = Name;
            CurrentUserProfile.Email = Email;
            CurrentUserProfile.StudentId = StudentId;
            CurrentUserProfile.ContactNumber = ContactNumber;
            await App.Database.SaveProfileAsync(CurrentUserProfile);
            await Shell.Current.Navigation.PopAsync();
        }
    }
}
