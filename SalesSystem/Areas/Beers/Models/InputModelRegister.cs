using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Zythum.Areas.Beers.Models
{
    public class InputModelRegister
    {
        
        [Required(ErrorMessage = "Beer Name is required.")]
        public string BeerName { set; get; }
        public string BeerStyle { set; get; }
        public string BeerABV { set; get; }
        public string BeerIBU { set; get; }

        [DataType(DataType.MultilineText)]
        public string BeerDescription { set; get; }
        public byte[] Image { get; set; }
        [Required(ErrorMessage = "Brewery is required.")]
        public int BreweryId { set; get; }
        public int BeerId { set; get; }

        [TempData]
        public string ErrorMessage { get; set; }

    }
}
