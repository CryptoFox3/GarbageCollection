using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarbageCollection.Models
{
    public class Addresses
    {
        public int StreetNumber { get; set; }
        public string Street { get; set; }
        public int AptNumber { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
    }
}