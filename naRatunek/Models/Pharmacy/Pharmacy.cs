using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace naRatunek.Models.Pharmacy
{
    public class Pharmacy
    {
        [Key]
        public int PharmacyId { get; set; }
        public string PharmacyName { get; set; }
        public string PharmacyType { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string FlatNumber { get; set; }
     

    }
}