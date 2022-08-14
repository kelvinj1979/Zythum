using System.ComponentModel.DataAnnotations;

namespace Zythum.Areas.Brewery.Models
{
    public class TReports_brewery
    {
        [Key]
        public int IdBrewReport { get; set; }
        public int TotalCheckIn { get; set; }
        public int TotalUser { get; set; }
        public int TotalLike { get; set; }
        public TBrewery TBrewerys { get; set; }


    }
}
