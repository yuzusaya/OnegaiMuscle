using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnegaiMuscle.Models;

namespace OnegaiMuscle
{
    public class MuscleDatabase
    {
        readonly SQLiteAsyncConnection database;

        public MuscleDatabase()
        {
            database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            database.CreateTableAsync<UserProfile>().Wait();
        }

        public Task<List<UserProfile>> GetLocationsAsync()
        {
            return database.Table<UserProfile>().ToListAsync();
        }

        public Task<int> SaveProfileAsync(UserProfile item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteProfileAsync(UserProfile item)
        {
            return database.DeleteAsync(item);
        }
    }


}
}
