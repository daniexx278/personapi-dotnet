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
    public class EstudiosMvcController : Controller
    {
        private readonly PersonaDbContext _context;

        public EstudiosMvcController(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? idProf, int? ccPer)
        {
            if (idProf == null || ccPer == null)
                return NotFound();

            var estudio = await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefaultAsync(e =>
                    e.IdProf == idProf &&
                    e.CcPer == ccPer);

            if (estudio == null)
                return NotFound();

            return View(estudio);
        }
        public IActionResult Create()
        {
            ViewData["CcPer"] = new SelectList(_context.Personas.ToList(), "Cc", "Cc");
            ViewData["IdProf"] = new SelectList(_context.Profesions.ToList(), "Id", "Nom");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Estudio estudio)
        {
            if (!ModelState.IsValid)
            {
                return View(estudio);
            }

            try
            {
                _context.Estudios.Add(estudio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            ViewData["CcPer"] = new SelectList(_context.Personas, "Cc", "Cc", estudio.CcPer);
            ViewData["IdProf"] = new SelectList(_context.Profesions, "Id", "Nom", estudio.IdProf);
            return View(estudio);
        }

        public async Task<IActionResult> Edit(int? idProf, int? ccPer)
        {
            if (idProf == null || ccPer == null) return NotFound();

            var estudio = await _context.Estudios.FindAsync(idProf, ccPer);
            if (estudio == null) return NotFound();

            ViewData["CcPer"] = new SelectList(_context.Personas, "Cc", "Cc", estudio.CcPer);
            ViewData["IdProf"] = new SelectList(_context.Profesions, "Id", "Nom", estudio.IdProf);

            return View(estudio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int idProf, int ccPer, Estudio estudio)
        {
            if (!ModelState.IsValid) return View(estudio);

            _context.Update(estudio);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int idProf, int ccPer)
        {
            var estudio = await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefaultAsync(x => x.IdProf == idProf && x.CcPer == ccPer);

            return View(estudio);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int idProf, int ccPer)
        {
            var estudio = await _context.Estudios.FindAsync(idProf, ccPer);

            if (estudio != null)
            {
                _context.Estudios.Remove(estudio);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
 }