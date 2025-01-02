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
        // GET: Motorok/Result
        [HttpPost]
        public IActionResult Results(Models.Motorok model)
        {
            model.Calculate();
            return View("Results",model);
        }
    }
}
