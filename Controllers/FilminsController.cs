using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Data;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class FilminsController : Controller
    {
        private readonly DemoMVCContext _context;

        public FilminsController(DemoMVCContext context)
        {
            _context = context;
        }

        // GET: Filmins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Filmin.ToListAsync());
        }

        // GET: Filmins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmin = await _context.Filmin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmin == null)
            {
                return NotFound();
            }

            return View(filmin);
        }

        // GET: Filmins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,DateLancamento,Genero,Valor,Avaliacao")] Filmin filmin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmin);
        }

        // GET: Filmins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmin = await _context.Filmin.FindAsync(id);
            if (filmin == null)
            {
                return NotFound();
            }
            return View(filmin);
        }

        // POST: Filmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,DateLancamento,Genero,Valor,Avaliacao")] Filmin filmin)
        {
            if (id != filmin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilminExists(filmin.Id))
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
            return View(filmin);
        }

        // GET: Filmins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmin = await _context.Filmin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmin == null)
            {
                return NotFound();
            }

            return View(filmin);
        }

        // POST: Filmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmin = await _context.Filmin.FindAsync(id);
            _context.Filmin.Remove(filmin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilminExists(int id)
        {
            return _context.Filmin.Any(e => e.Id == id);
        }
    }
}
