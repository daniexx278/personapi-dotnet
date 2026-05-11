using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    public class TelefonosMvcController : Controller
    {
        private readonly PersonaDbContext _context;

        public TelefonosMvcController(PersonaDbContext context)
        {
            _context = context;
        }

        // LISTAR
        public async Task<IActionResult> Index()
        {
            return View(await _context.Telefonos
                .Include(t => t.DuenioNavigation)
                .ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
                return NotFound();

            var telefono = await _context.Telefonos
                .Include(t => t.DuenioNavigation)
                .FirstOrDefaultAsync(t => t.Num == id);

            if (telefono == null)
                return NotFound();

            return View(telefono);
        }

        // CREATE GET
        public IActionResult Create()
        {
            ViewData["Duenio"] = new SelectList(_context.Personas.ToList(), "Cc", "Cc");
            return View();
        }

        // CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Telefono telefono)
        {
            //MOSTRAR ERROR REAL SI FALLA
            if (!ModelState.IsValid)
            {
                return View(telefono);
            }

            try
            {
                _context.Telefonos.Add(telefono);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            ViewData["Duenio"] = new SelectList(_context.Personas, "Cc", "Cc", telefono.Duenio);
            return View(telefono);
        }

        // EDIT GET
        public async Task<IActionResult> Edit(string id)
        {
            var telefono = await _context.Telefonos.FindAsync(id);
            if (telefono == null) return NotFound();

            ViewData["Duenio"] = new SelectList(_context.Personas, "Cc", "Cc", telefono.Duenio);
            return View(telefono);
        }

        // EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Telefono telefono)
        {
            if (id != telefono.Num) return NotFound();

            if (!ModelState.IsValid) return View(telefono);

            _context.Update(telefono);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // DELETE GET
        public async Task<IActionResult> Delete(string id)
        {
            var telefono = await _context.Telefonos
                .Include(t => t.DuenioNavigation)
                .FirstOrDefaultAsync(x => x.Num == id);

            return View(telefono);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var telefono = await _context.Telefonos.FindAsync(id);

            if (telefono != null)
            {
                _context.Telefonos.Remove(telefono);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}