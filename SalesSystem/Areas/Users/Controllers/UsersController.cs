using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SalesSystem.Areas.Users.Models;
using SalesSystem.Controllers;
using SalesSystem.Data;
using SalesSystem.Library;
using SalesSystem.Models;
using System.Data;
using System.Data.SqlClient;
using Zythum.Models;
using SqlCommand = System.Data.SqlClient.SqlCommand;
using Microsoft.Extensions.Configuration;
using SqlConnection = System.Data.SqlClient.SqlConnection;
using Microsoft.AspNetCore.Mvc;

namespace SalesSystem.Areas.Users.Controllers
{
    [Area("Users")]
    //[Authorize]
    public class UsersController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;
        private LUser _user;
        private static DataPaginador<InputModelRegister> models;
        private readonly string _linkSql;

        public UsersController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration config,
            ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _user = new LUser(userManager, signInManager, roleManager, context);
            _linkSql = config.GetConnectionString("DefaultConnection");
        }

        
        public IActionResult Users(int id, String filtrar, int registros)
        {
            if (_signInManager.IsSignedIn(User))
            {
                Object[] objects = new Object[3];
                var data = _user.getTUsuariosAsync(filtrar, 0);
                if (0 < data.Result.Count)
                {
                    var url = Request.Scheme + "://" + Request.Host.Value;
                    objects = new LPaginador<InputModelRegister>().paginador(data.Result,
                        id, registros, "Users", "Users", "Users", url);
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
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public JsonResult ListCountry()
        {
            List<Country> lCountry = new List<Country>();
            using (var cn = new SqlConnection(_linkSql))
            {
                cn.Open();
                var cmd = new SqlCommand("sp_country", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lCountry.Add(new Country
                        {
                            CountryId = dr["CountryId"].ToString(),
                            NamePT = dr["NamePT"].ToString(),
                            NameEN = dr["NameEN"].ToString(),
                            NameES = dr["NameES"].ToString(),
                            Iso3 = dr["Iso3"].ToString()
                        });
                    }
                }

            }

            return Json(lCountry);
        }
    }
}