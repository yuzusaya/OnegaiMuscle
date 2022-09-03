using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnegaiMuscle.Services
{
    public partial class AlertService
    {
        public enum Duration
        {
            Short,
            Long
        }

        public partial void ShowToast(string message, Duration duration=Duration.Short);
    }
}
