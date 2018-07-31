using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarbageCollection.Models
{
    public class Pickups
    {
        [Key]
        public int PickupId { get; set; }
        public DateTime PickupDate { get; set; }
        public int CustomerId { get; set; }
        public int Zipcode { get; set; }
        public bool Repeat { get; set; }
        public bool IsCompleted {get; set;}
        
    }
}