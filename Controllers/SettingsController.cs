using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GardenMonitoring.Data;
using GardenMonitoring.Models;

namespace GardenMonitoring.Controllers
{
	public class SettingsController : Controller
    {
        private readonly PlantContext _context;

        public SettingsController(PlantContext context)
        {
            _context = context;
        }

        // GET: Settings
        public Task<IActionResult> Index()
        {
            return Task.FromResult<IActionResult>(View(_context.Settings.First()));
        }

        // GET: Settings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settings = await _context.Settings.FirstAsync();

            return View(settings);
        }

        // GET: Settings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settings = await _context.Settings.FirstAsync();
			return View(settings);
        }

        // POST: Settings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaxTemperature,MinTemperature,MaxLight,MinLight,MaxPressure,MinPressure,MaxHumidity,MinHumidity")] Settings settings)
        {
            if (id != settings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(settings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SettingsExists(settings.Id))
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
            return View(settings);
        }


        private bool SettingsExists(int id)
        {
            return (true);
        }
    }
}
