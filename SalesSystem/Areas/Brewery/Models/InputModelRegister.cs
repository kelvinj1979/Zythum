using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Zythum.Areas.Brewery.Models
{
    public class InputModelRegister
    {

        // BreweryId int,
        [Required(ErrorMessage = "Brewery Name is required.")]
        public string BreweryName { set; get; }
        public string BreweryAdress { set; get; }
        public string BreweryWeb { set; get; }
        //public string CountryId { set; get; }
        public byte[] Image { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        


    }
}
