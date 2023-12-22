using FukLinux.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc.Html;

namespace FukLinux.Controllers
{
    public class UserController : Controller
    {
        
        // GET: BeerController
        public ActionResult Index()
        {
            return View(Data.Users);
        }

        // GET: BeerController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = Data.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: BeerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BeerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,FirstName,LastName,Stage")] User user)
        {
            try
            {
                Data.Users.Add(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(user);
            }
        }

        // GET: BeerController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = Data.Users.Find(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        

        // POST: BeerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,FirstName,LastName,Stage")] User user)
        {
            try
            {
                Data.Users[id].FirstName = user.FirstName;
                Data.Users[id].LastName = user.LastName;
                Data.Users[id].Stage = user.Stage;
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

            var user = Data.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: BeerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var user = Data.Users.Find(x => x.Id == id);
            if (user != null)
            {
                Data.Users.Remove(user);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
