using SQLite;

using System;
using System.Collections.Generic;
using System.Text;

namespace TestCheckBox
{
    public class Cities
    {
        [PrimaryKey, AutoIncrement]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
    }
}
