﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using OnegaiMuscle.Models;

namespace OnegaiMuscle.ViewModels
{
    public class MainPageViewModel
    {
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
        public int SelectedUserProfileId { get; set; }

        public string SelectedSession { get; set; }

        public ICommand SubmitCommand => new Command(async () =>
        {
            //if (string.IsNullOrWhiteSpace(SelectedSession))
            //{
            //    return;
            //}

            //if (SelectedUserProfileId == 0)
            //{
            //    return;
            //}
            var today = DateTime.Today;
#warning record and check last submitted date of selected user
            var lastSubmittedDate = Preferences.Get("LastSubmitDate", DateTime.MinValue);
            if (lastSubmittedDate == today)
            {
                if (!await Shell.Current.DisplayAlert("Warning",
                        "You have submitted the form today. Are you sure you want to submit next form?", "Yes", "No"))
                    return;
            }
#warning to be replaced
            var user = new UserProfile()
            {
                ContactNumber = "0122291202",
                Email = "bcs1090212@student.uts.edu.my",
                Name = "David Lim",
                StudentId = "bcs1212110209"
            };
            try
            {
                HttpClient httpClient = new HttpClient();
                var url = new Uri($"https://docs.google.com/forms/u/0/d/e/1FAIpQLSdYrqClc4Knm6sFzeUY8ldazQBQteMCv6-d9xWo47V4Ne-K0A/formResponse?entry.135433756={user.Name}&entry.1463710679={user.StudentId}&entry.390244614={user.ContactNumber}&entry.984636927_year={today.Year}&entry.984636927_month={today.Month}&entry.984636927_day={today.Day}&entry.1493146651={SelectedSession}&emailAddress={user.Email}");
                //var response = await httpClient.PostAsync("https://docs.google.com/forms/u/0/d/e/1FAIpQLScCOeWb1_DXr2RpNgtn1QyxhOAxll6eZysPHIlysf6HDobGxg/formResponse?entry.366340186=Option 2", null);
                var response = await httpClient.PostAsync(url, null);
                response.EnsureSuccessStatusCode();
                Preferences.Set("LastSubmitDate",DateTime.Today);
            }
            catch (Exception e)
            {
                await Shell.Current.DisplayAlert("Error", e.Message, "ok");
            }
        });
    }
}
