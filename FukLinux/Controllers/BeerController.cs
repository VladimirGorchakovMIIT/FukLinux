using FukLinux.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FukLinux.Controllers
{
    public class BeerController : Controller
    {
        
        // GET: BeerController
        public ActionResult Index()
        {
            return View(Data.Beers);
        }

        // GET: BeerController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = Data.Beers.FirstOrDefault(x => x.Id == id);

            if (beer == null)
            {
                return NotFound();
            }

            return View(beer);
        }

        // GET: BeerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BeerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Name,Description")] Beer beer)
        {
            try
            {
                Data.Beers.Add(beer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(beer);
            }
        }

        // GET: BeerController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = Data.Beers.Find(x => x.Id == id);

            if (beer == null)
            {
                return NotFound();
            }

            return View(beer);
        }

        // POST: BeerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Name,Description")] Beer beer)
        {
            try
            {
                Data.Beers[id].Name = beer.Name;
                Data.Beers[id].Description = beer.Description;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BeerController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = Data.Beers.FirstOrDefault(x => x.Id == id);
            if (beer == null)
            {
                return NotFound();
            }

            return View(beer);
        }

        // POST: BeerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var beer = Data.Beers.Find(x => x.Id == id);
            if (beer != null)
            {
                Data.Beers.Remove(beer);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
