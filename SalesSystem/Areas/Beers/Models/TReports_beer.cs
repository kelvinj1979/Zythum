using System.ComponentModel.DataAnnotations;

namespace Zythum.Areas.Beers.Models
{
    public class TReports_beer
    {
        [Key]
        public int IdBeerReport { get; set; }
        public int TotalCheckIn { get; set; }
        public int TotalRating { get; set; }
        public int TotalLike { get; set; }
        public TBeers TBeers { get; set; }
    }
}
