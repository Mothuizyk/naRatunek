using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace naRatunek.Models.Hospitals
{
    public class Hospital
    {
        [Key]
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string Name { get; set; }
        public string Specialisation { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }

}