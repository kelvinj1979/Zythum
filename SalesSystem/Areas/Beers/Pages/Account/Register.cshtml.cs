using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Data;
using SalesSystem.Library;
using System;
using System.Linq;
using System.Threading.Tasks;
using Zythum.Areas.Beers.Models;

namespace Zythum.Areas.Beers.Pages.Account
{
   
    [Area("Beers")]
    public class RegisterModel : PageModel
    {
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;
        private static InputModel _dataInput;
        private Uploadimage _uploadimage;
        private static InputModelRegister _dataBeer1, _dataBeer2;
        private IWebHostEnvironment _environment;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context,
            IWebHostEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _environment = environment;
            _uploadimage = new Uploadimage();
        }
        public void OnGet()
        {
            Input = new InputModel
            {

            };
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel : InputModelRegister
        {
            public IFormFile AvatarImage { get; set; }
            //[TempData]
            //public string ErrorMessage { get; set; }

        }

        public async Task<IActionResult> OnPost(String dataBeer)
        {
            if (dataBeer == null)
            {
                if (_dataBeer2 == null)
                {
                    if (await SaveAsync())
                    {
                        return Redirect("/Beers/Beers?area=Beers");
                    }
                    else
                    {
                        return Redirect("/Beers/Register");
                    }
                }
                else
                {
                    //if (await UpdateAsync())
                    //{
                    //    var url = $"/Brewery/Account/Details?id={_dataUser2.Id}";
                    //    _dataUser2 = null;
                    //    return Redirect(url);
                    //}
                    //else
                    //{
                    //    return Redirect("/Brewery/Register");
                    //}

                    return null;
                }
            }
            else
            {
                // _dataUser1 = JsonConvert.DeserializeObject<InputModelRegister>(dataUser);
                return Redirect("/Beers/Register?id=1");
            }



        }

        private async Task<bool> SaveAsync()
        {
            _dataInput = Input;
            var valor = false;
            if (ModelState.IsValid)
            {
                //var beerList = _context.TBeers.Where(u => u.BeerName.Equals(Input.BeerName)).ToList();
                //if (beerList.Count.Equals(0))
                //{
                    var strategy = _context.Database.CreateExecutionStrategy();
                    await strategy.ExecuteAsync(async () =>
                    {
                        using (var transaction = _context.Database.BeginTransaction())
                        {
                            try
                            {
                                var imageByte = await _uploadimage.ByteAvatarImageAsync(
                                            Input.AvatarImage, _environment, "img/beercup.png");
                                var t_beer = new TBeers
                                {
                                    BeerName = Input.BeerName,
                                    BeerStyle = Input.BeerStyle,
                                    BeerABV = Input.BeerABV,
                                    BeerIBU = Input.BeerIBU,
                                    BeerDescription = Input.BeerDescription,
                                    BreweryId = Input.BreweryId,
                                    Image = imageByte,
                                };
                                await _context.AddAsync(t_beer);
                                _context.SaveChanges();

                                var t_Rep_beer = new TReports_beer
                                {
                                    TotalCheckIn = 0,
                                    TotalRating = 0,
                                    TotalLike = 0,
                                    TBeers = t_beer
                                };
                                await _context.AddAsync(t_Rep_beer);
                                _context.SaveChanges();

                                transaction.Commit();
                                _dataInput = null;
                                valor = true;
                            }
                            catch (Exception ex)
                            {

                                _dataInput.ErrorMessage = ex.Message;
                                transaction.Rollback();
                                valor = false;
                            }
                        }

                    });
                //}
                //else
                //{
                //    _dataInput.ErrorMessage = $"This {Input.BeerName} is already register";
                //    valor = false;

                //}


            }
            else
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _dataInput.ErrorMessage += error.ErrorMessage;
                    }
                }
                valor = false;
            }

            return valor;
        }
    }
    
}