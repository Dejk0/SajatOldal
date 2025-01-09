using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SajatOldal.Models.Motorok;
using SajatOldalProba.Data;
using System.ComponentModel.DataAnnotations;

namespace SajatOldal.Controllers
{
    public class MotorokController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MotorokController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Motorok
        public async Task<IActionResult> Index()
        {
            return View(await _context.Services.ToListAsync());
        }
        // GET: Motorok/Result
        [HttpPost]
        public async Task<IActionResult> Results(Motorok model)
        {

            model.Calculate();
            return View(model);
        }
       

        // GET:  Motorok/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorok = await _context.Services
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motorok == null)
            {
                return NotFound();
            }
            
            return View("Results", motorok);
        }

        // GET:  Motorok/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST:  Motorok/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(  Motorok motorok)
        {
            
            if (ModelState.IsValid)
            {
                motorok.Id = Guid.NewGuid();
                motorok.Calculate();
            _context.Add(motorok);
            await _context.SaveChangesAsync();
                return await Details(motorok.Id);
            }            
            return View("Create2",motorok);
        }

        // GET:  Motorok/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorok = await _context.Services.FindAsync(id);
            if (motorok == null)
            {
                return NotFound();
            }
            return View(motorok);
        }


        // POST:  Motorok/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("P_M_Max,Id,Pn_max,n_pn_max,M_max,n_M_max,Weight,Max_Weight,Transmissions,Gear_ratio,Length,Width,Hight,Wheelbase,Gauge,Tire,Drag_coefficient,Rolling_Resistance_Factor,Transmission_efficiency,Reduction_constant_of_rotating_masses,Slope_of_rise,Adhesion_factor,Creep_factor,Wheel_radius,M_P_Max,Speed_of_the_Wheels_P,Speed_of_the_Wheels_M,Force_of_the_Wheels_P,Force_of_the_Wheels_M,Rolling_resistance,The_hill_on_degree,Rolling_resistance_on_a_hill,Ascent_resistance,AirResistances_P,AirResistances_M,AirDensity,Cross_Section,ForcesRequiredForAccelaration_P,ForcesRequiredForAccelaration_M,Accelarations_On_The_Hill_P,Accelarations_On_The_Hill_M,Dynamic_Factors,ForceAgistTheCar_P,ForceAgistTheCar_M,Speed_In_Kmperh_P,Speed_In_Kmperh_M")] Motorok motorok)
        {
            if (id != motorok.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    motorok.Calculate();
                    _context.Update(motorok);                   
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotorokExists(motorok.Id))
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
            return View(motorok);
        }

        // GET:  Motorok/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorok = await _context.Services
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motorok == null)
            {
                return NotFound();
            }

            return View(motorok);
        }

        // POST:  Motorok/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var motorok = await _context.Services.FindAsync(id);
            if (motorok != null)
            {
                _context.Services.Remove(motorok);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool MotorokExists(Guid id)
        {
            return _context.Services.Any(e => e.Id == id);
        }
    }
}
