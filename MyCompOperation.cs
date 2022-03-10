using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestCheckBox
{
    public class MyCompOperation
    {
        readonly SQLiteAsyncConnection db;

        public MyCompOperation(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<MyCompTabel>().Wait();
            db.CreateTableAsync<Cities>().Wait();
            db.CreateTableAsync<Countries>().Wait();
        }
        //Get all Companies.
        public Task<List<MyCompTabel>> GetAllCompAsync()
        {
            return db.Table<MyCompTabel>().ToListAsync();
        }
        //Get all Countries.
        public Task<List<Countries>> GetAllCountryAsync()
        {
            return db.Table<Countries>().ToListAsync();
        }
        //Get Country.
        public Task<Countries> GetCountryAsync(string name)
        {
            return db.Table<Countries>().Where(i => i.CountryName == name).FirstOrDefaultAsync();
        }

        //Get Country Name.
        public Task<Countries> GetCountryCodeAsync(string code)
        {
            return db.Table<Countries>().Where(i => i.CountryCode == code).FirstOrDefaultAsync();
        }
        //// Get all people living in address by HomeNumber and City.
        //public Task<List<MyCompTabel>> GetAllCompAsync(string name)
        //{
        //    return db.Table<MyCompTabel>().Where(i => i.Name == name).ToListAsync();
        //}
        public Task<MyCompTabel> GetCompAsync(string name)
        {
            return db.Table<MyCompTabel>().Where(i => i.Name == name).FirstOrDefaultAsync();
        }

        public Task<Cities> GetCityAsync(string name)
        {
            return db.Table<Cities>().Where(i => i.CityName == name).FirstOrDefaultAsync();
        }
        //Get all Cities.
        public Task<List<Cities>> GetAllCityAsync(string countryname)
        {
            return db.Table<Cities>().Where(i => i.CountryName == countryname).ToListAsync();
        }

        public Task<int> SaveCompAsync(MyCompTabel comp)
        {
            if (comp.Id != 0)
            {
                // Update an existing address.
                return db.UpdateAsync(comp);
            }
            else
            {
                // Save a new address.
                return db.InsertAsync(comp);
            }
        }

        public Task<int> SaveCityAsync(Cities city)
        {
            if (city.CityId != 0)
            {
                // Update an existing address.
                return db.UpdateAsync(city);
            }
            else
            {
                // Save a new address.
                return db.InsertAsync(city);
            }
        }

        public Task<int> SaveCountryAsync(Countries country)
        {
            if (country.CountryId != 0)
            {
                // Update an existing address.
                return db.UpdateAsync(country);
            }
            else
            {
                // Save a new address.
                return db.InsertAsync(country);
            }
        }
        // Delete address.
        public Task<int> DeleteAddressAsync(MyCompTabel comp)
        {
            return db.DeleteAsync(comp);
        }
    }
}