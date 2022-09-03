using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnegaiMuscle.Models
{
    public class BookingRecord
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string StudentId { get; set; }
        public string ContactNumber { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
