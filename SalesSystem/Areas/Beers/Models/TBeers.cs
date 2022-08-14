using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zythum.Areas.Beers.Models
{
    public class TBeers
    {
        [Key]
        public int BeerId { set; get; }
        public string BeerName { set; get; }
        public string BeerStyle { set; get; }
        public string BeerABV { set; get; }
        public string BeerIBU { set; get; }
        public string BeerDescription { set; get; }
        public byte[] Image { get; set; }
        [ForeignKey("TBrewery")]
        public int BreweryId { set; get; }
        public List<TReports_beer> TReports_beer { get; set; }
    }
}
