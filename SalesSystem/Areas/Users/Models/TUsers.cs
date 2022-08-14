using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Zythum.Models;

namespace SalesSystem.Areas.Users.Models
{
    public class TUsers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NID { get; set; }
        public string Email { get; set; }
        public string IdUser { get; set; }
        public DateTime Birthday { get; set; }
        public string GenderId { get; set; }
        [ForeignKey("Country")]        
        public string CountryId { get; set; }
        public virtual Country Country { get; set; }
        public string City { get; set; }
        public string AboutYou { get; set; }
        public byte[] Image { get; set; }
    }
}
