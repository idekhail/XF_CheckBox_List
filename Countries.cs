using SQLite;

using System;
using System.Collections.Generic;
using System.Text;

namespace TestCheckBox
{
    public class Countries
    {
        [PrimaryKey, AutoIncrement]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

    }
}
