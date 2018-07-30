using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarbageCollection.Models
{
    public class CustomerModels : ApplicationUser
    {
        [Key]
        public int CustomersId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public int AmountDue { get; set; }
        public DateTime PickupDate { get; set; }
        
      
    }
}