using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalesSystem.Data;
using SalesSystem.Library;
using System.Linq;
using Zythum.Areas.Beers.Models;

namespace Zythum.Areas.Beers.Pages.Account
{
    public class BeerDetailModel : PageModel
    {
        private SignInManager<IdentityUser> _signInManager;
        private LBeers _beer;
        public BeerDetailModel(
            ApplicationDbContext context)
        {
           // _signInManager = signInManager;
           // _beer = new LBeers(userManager, signInManager, roleManager, context);
            _beer = new LBeers(context);
        }
        public void OnGet(int id)
        {
            var data = _beer.getTBeerAsync(null, id);
            if (0 < data.Result.Count)
            {
                Input = new InputModel
                {
                    DataBeer = data.Result.ToList().Last(),
                };
            }
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            public InputModelRegister DataBeer { get; set; }
        }
    }
}
