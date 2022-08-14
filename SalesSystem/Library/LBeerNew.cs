using Microsoft.AspNetCore.Identity;
using SalesSystem.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zythum.Areas.Beers.Models;

namespace Zythum.Library
{
	public class LBeerNew
	{
        //private ApplicationDbContext context;

        //public LBeerNew(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //public LBeerNew(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        //{

        //    _context = context;
        //}
        //public async Task<List<InputModelRegister>> getTBeerAsync(String valor, int id)
        //{
        //    List<TBeers> listBeer;
        //    // List<SelectListItem> _listBrewery;
        //    // List<InputModelRegister> beerList = new List<InputModelRegister>();
        //    var beerList = new List<InputModelRegister>();
        //    if (valor == null && id.Equals(0))
        //    {
        //        listBeer = _context.TBeers.ToList();
        //    }
        //    else
        //    {
        //        if (id.Equals(0))
        //        {
        //            listBeer = _context.TBeers.Where(u => u.BeerName.StartsWith(valor) || u.BeerStyle.StartsWith(valor) ||
        //            u.BeerDescription.StartsWith(valor) || u.BeerABV.StartsWith(valor) || u.BeerIBU.StartsWith(valor)).ToList();
        //        }
        //        else
        //        {
        //            listBeer = _context.TBeers.Where(u => u.BeerId.Equals(id)).ToList();
        //        }
        //    }
        //    if (!listBeer.Count.Equals(0))
        //    {
        //        foreach (var item in listBeer)
        //        {
        //            // _listBrewery = await _usersRole.getRole(_userManager, _roleManager, item.IdUser);
        //            var user = _context.TBeers.Where(u => u.BeerId.Equals(item.BeerId)).ToList().Last();
        //            beerList.Add(new InputModelRegister
        //            {
        //                BeerId = (int)item.BeerId,
        //                BeerName = item.BeerName,
        //                BeerStyle = item.BeerStyle,
        //                BeerIBU = item.BeerIBU,
        //                BeerABV = item.BeerABV,
        //                BeerDescription = item.BeerDescription,
        //                Image = item.Image
        //            });
        //            // _listRoles.Clear();
        //        }
        //    }
        //    return beerList;
        //}
    }
}
