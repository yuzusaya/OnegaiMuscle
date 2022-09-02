using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnegaiMuscle.Models
{
    public class UserProfile
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotifyParentProperty(true)]
        public string Name { get; set; }
        [NotifyParentProperty(true)]
        public string Email { get; set; }
        [NotifyParentProperty(true)]
        public string StudentId { get; set; }
        [NotifyParentProperty(true)]
        public string ContactNumber { get; set; }
    }
}
