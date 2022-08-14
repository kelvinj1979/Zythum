using System.ComponentModel.DataAnnotations;

namespace Zythum.Models
{
    public class Country
    {
        [Key]
        [MaxLength(3)]
        public string CountryId { get; set; }
        public string NamePT { get; set; }
        public string NameEN { get; set; }
        public string NameES { get; set; }
        public int NumCode { get; set; } 
        [MaxLength(3)]
        public string Iso3 { get; set; }
       
    }
}
