using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.entities;
using infrastructure;
using web.viewModel;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Core.Interfaces;

namespace web.Controllers
{
    public class PortfolioItemsController : Controller
    {
        private readonly IUnitOfWork<PortfolioItem> _portfolio;
        private readonly IHostingEnvironment _hosting;

        public PortfolioItemsController(IUnitOfWork<PortfolioItem> portfolio, IHostingEnvironment hosting)
        {
            _portfolio = portfolio;
            _hosting = hosting;
        }

        // GET: PortfolioItems
        public IActionResult Index()
        {
            return View(_portfolio.entity.GetAll());
        }

        // GET: PortfolioItems/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioItem = _portfolio.entity.GetById(id);
            if (portfolioItem == null)
            {
                return NotFound();
            }

            return View(portfolioItem);
        }

        // GET: PortfolioItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PortfolioItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(portfolioViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.File!=null)
                {
                    //save the File at the level of the root in portfolio folder
                    string uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string Fullpath = Path.Combine(uploads, model.File.FileName);
                    model.File.CopyTo(new FileStream(Fullpath, FileMode.Create));
                }
                //mapping the version to EF
                PortfolioItem portfolioItem = new PortfolioItem
                {
                    ProjectName = model.ProjectName,
                    Discreption = model.Discreption,
                    ImageUrl = model.File.FileName,
                    id=model.id,

                };
                //insert and save in UnitOfWork
                _portfolio.entity.Insert(portfolioItem);
                _portfolio.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PortfolioItems/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioItem = _portfolio.entity.GetById(id);
            if (portfolioItem == null)
            {
                return NotFound();
            }
            portfolioViewModel portfolioViewModel = new portfolioViewModel
            {
                ProjectName = portfolioItem.ProjectName,
                Discreption = portfolioItem.Discreption,
                ImageUrl = portfolioItem.ImageUrl,
                id = portfolioItem.id,
            };

            return View(portfolioViewModel);
        }

        // POST: PortfolioItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id,portfolioViewModel model)
        {
            if (id != model.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (model.File != null)
                    {
                        //save the File at the level of the root in portfolio folder
                        string uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                        string Fullpath = Path.Combine(uploads, model.File.FileName);
                        model.File.CopyTo(new FileStream(Fullpath, FileMode.Create));
                    }
                    //mapping the version to EF
                    PortfolioItem portfolioItem = new PortfolioItem
                    {
                        ProjectName = model.ProjectName,
                        Discreption = model.Discreption,
                        ImageUrl = model.File.FileName,
                        id = model.id,

                    };
                    //insert and save in UnitOfWork
                    _portfolio.entity.Update(portfolioItem);
                    _portfolio.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioItemExists(model.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PortfolioItems/Delete/5
        public  IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioItem = _portfolio.entity.GetById(id);
            if (portfolioItem == null)
            {
                return NotFound();
            }

            return View(portfolioItem);
        }

        // POST: PortfolioItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _portfolio.entity.Delete(id);
            _portfolio.Save();
            return RedirectToAction(nameof(Index));

        }

        private bool PortfolioItemExists(Guid id)
        {
            return _portfolio.entity.GetAll().Any(e => e.id == id);
        }
    }
}
