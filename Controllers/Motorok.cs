using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SajatOldal.Controllers
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
        public IActionResult Results(Models.Motorok.Motorok model)
        {

            //TransmissionsValidation(model);
            //if (!ModelState.IsValid)
            //{
            //    return View("Index", model);
            //}
            model.Calculate();
            return View("Results",model);
        }
        public void TransmissionsValidation(Models.Motorok.Motorok model)
        {

            for (int i = 0; i < model.Transmissions.Count; i++) 
            {
                if (model.Transmissions[i] < 0.2 || model.Transmissions[i] > 10 )
                {
                    ModelState.AddModelError($"Transmissions[{i}]", $"A {i+1}. sebességfokozat értéknek üresnek vagy 0.2 és 10 között kell lennie.");
                }
            }
        }
    }
}
