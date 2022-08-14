using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Zythum.Areas.Brewery.Models
{
    public class TBrewery
    {
        [Key]
        public int IdBrewery { get; set; }
        public string BreweryName { get; set; }
        public string BreweryAdress { get; set; }
        public string BreweryWeb { get; set; }
        //public string CountryId { set; get; }
        public byte[] Image { get; set; }
        public List<TReports_brewery> TReports_brewery { get; set; }
    }
}
