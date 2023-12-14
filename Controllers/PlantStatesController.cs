using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GardenMonitoring.Data;
using GardenMonitoring.Models;

namespace GardenMonitoring.Controllers
{
    public class PlantStatesController : Controller
    {
        private readonly PlantContext _context;

        public PlantStatesController(PlantContext context)
        {
            _context = context;
        }

        // GET: PlantStates
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlantState.ToListAsync());
        }

        // GET: PlantStates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantState = await _context.PlantState
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plantState == null)
            {
                return NotFound();
            }

            return View(plantState);
        }

        // GET: PlantStates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlantStates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlantId,TimeStamp,Temperature,Light,Pressure,Humidity")] PlantState plantState)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plantState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plantState);
        }

        // GET: PlantStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantState = await _context.PlantState.FindAsync(id);
            if (plantState == null)
            {
                return NotFound();
            }
            return View(plantState);
        }

        // POST: PlantStates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlantId,TimeStamp,Temperature,Light,Pressure,Humidity")] PlantState plantState)
        {
            if (id != plantState.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plantState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantStateExists(plantState.Id))
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
            return View(plantState);
        }

        // GET: PlantStates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantState = await _context.PlantState
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plantState == null)
            {
                return NotFound();
            }

            return View(plantState);
        }

        // POST: PlantStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plantState = await _context.PlantState.FindAsync(id);
            if (plantState != null)
            {
                _context.PlantState.Remove(plantState);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantStateExists(int id)
        {
            return _context.PlantState.Any(e => e.Id == id);
        }
    }
}
