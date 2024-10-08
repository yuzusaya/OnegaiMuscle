﻿using SQLite;
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
            database.CreateTableAsync<BookingRecord>().Wait();
        }

        public Task<UserProfile> GetProfileByIdAsync(int id)
        {
            return database.Table<UserProfile>().FirstOrDefaultAsync(x=>x.Id==id);
        }

        public Task<List<UserProfile>> GetProfilesAsync()
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

        public Task<List<BookingRecord>> GetBookingRecordsAsync()
        {
            return database.Table<BookingRecord>().ToListAsync();
        }

        public Task<int> AddBookingRecordAsync(BookingRecord record)
        {
            return database.InsertAsync(record);
        }

        public async Task<BookingRecord> GetLastBookingRecord()
        {
            var records = await database.Table<BookingRecord>().ToListAsync();
            return records.LastOrDefault();
        }
    }
}
