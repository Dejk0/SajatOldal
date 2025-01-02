using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SajatOldalProba.Controllers
{
    public class Motorok : Controller
    {
        // GET: Motorok
        public ActionResult Index()
        {
            return View();
        }

        // GET: Motorok/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Motorok/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Motorok/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Motorok/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Motorok/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Motorok/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Motorok/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
