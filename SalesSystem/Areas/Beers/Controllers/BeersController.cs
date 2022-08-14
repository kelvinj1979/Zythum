using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SalesSystem.Data;
using SalesSystem.Library;
using SalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Zythum.Areas.Beers.Models;
using Zythum.Areas.Brewery.Models;
using InputModelRegister = Zythum.Areas.Beers.Models.InputModelRegister;

namespace Zythum.Areas.Beers.Controllers
{
    [Area("Beers")]
    public class BeersController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;
        private LBeers _beer;
        private static DataPaginador<InputModelRegister> models;
        private readonly string _linkSql;

        public BeersController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration config,
            ApplicationDbContext context)
        {
            _signInManager = signInManager;
           // _user = new LUser(userManager, signInManager, roleManager, context);
            _beer = new LBeers(context);
            _linkSql = config.GetConnectionString("DefaultConnection");
        }

        
        public IActionResult Beers(int id, String filtrar, int registros)
        {
            if (_signInManager.IsSignedIn(User))
            {
                Object[] objects = new Object[3];
                var data = _beer.getTBeerAsync(filtrar, 0);
                if (0 < data.Result.Count)
                {
                    var url = Request.Scheme + "://" + Request.Host.Value;
                    objects = new LPaginador<InputModelRegister>().paginador(data.Result,
                        id, registros, "Beers", "Beers", "Beers", url);
                }
                else
                {
                    objects[0] = "There is no data to show";
                    objects[1] = "There is no data to show";
                    objects[2] = new List<InputModelRegister>();
                }
                models = new DataPaginador<InputModelRegister>
                {
                    List = (List<InputModelRegister>)objects[2],
                    Pagi_info = (String)objects[0],
                    Pagi_navegacion = (String)objects[1],
                    Input = new InputModelRegister(),
                };
                return View(models);

            }
            else
            {
                return Redirect("/");
            }
        }

        public JsonResult ListBrewery()
        {
            List<TBrewery> lBrewery = new List<TBrewery>();
            using (var cn = new SqlConnection(_linkSql))
            {
                cn.Open();
                var cmd = new SqlCommand("sp_brewery", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lBrewery.Add(new TBrewery
                        {
                            IdBrewery = (int)dr["IdBrewery"],
                            BreweryName = dr["BreweryName"].ToString(),
                            BreweryAdress = dr["BreweryAdress"].ToString(),
                            BreweryWeb = dr["BreweryWeb"].ToString()
                        });
                    }
                }

            }

            return Json(lBrewery);
        }
    }
}
