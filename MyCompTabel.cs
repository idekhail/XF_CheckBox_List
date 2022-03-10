using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCheckBox
{
    public class MyCompTabel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompSize { get; set; }
        public bool Online { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
