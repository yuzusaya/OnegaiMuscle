using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnegaiMuscle.Services
{
    public partial class AlertService
    {
        public partial void ShowToast(string message, Duration duration = Duration.Short)
        {
            ToastLength length = duration == Duration.Short ? ToastLength.Short : ToastLength.Long;
            var toast = Toast.MakeText(Android.App.Application.Context, message, length);
            if (toast != null)
            {
                toast.SetGravity(GravityFlags.Center, 0, 0);
                toast.Show();
            }
        }
    }
}
