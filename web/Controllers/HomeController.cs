using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using web.viewModel;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Owner> _owner;
        private readonly IUnitOfWork<PortfolioItem> _portfolioitem;

        public HomeController(IUnitOfWork<Owner> owner, IUnitOfWork<PortfolioItem> portfolio)
        {
           _owner = owner;
            _portfolioitem = portfolio;
        }
        public IActionResult Index()
        {
            var HomeViewModel = new HomeViewModel
            {
                Owner = _owner.entity.GetAll().First(),
                PortfolioItems =_portfolioitem.entity.GetAll().ToList()

            };
            return View(HomeViewModel);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}