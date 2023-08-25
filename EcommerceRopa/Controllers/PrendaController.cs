using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcommerceRopa.Models;

namespace EcommerceRopa.Controllers
{
    public class PrendaController : Controller
    {
        private readonly DBCrudContext _context;

        public PrendaController(DBCrudContext context)
        {
            _context = context;
        }

        // GET: Prenda
        public async Task<IActionResult> Index()
        {
              return _context.Prenda != null ? 
                          View(await _context.Prenda.ToListAsync()) :
                          Problem("Entity set 'DBCrudContext.Prenda'  is null.");
        }

        // GET: Prenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prenda == null)
            {
                return NotFound();
            }

            var prenda = await _context.Prenda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prenda == null)
            {
                return NotFound();
            }

            return View(prenda);
        }

        // GET: Prenda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Talla,Precio,Color,Marca,Estilo")] Prenda prenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prenda);
        }

        // GET: Prenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prenda == null)
            {
                return NotFound();
            }

            var prenda = await _context.Prenda.FindAsync(id);
            if (prenda == null)
            {
                return NotFound();
            }
            return View(prenda);
        }

        // POST: Prenda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Talla,Precio,Color,Marca,Estilo")] Prenda prenda)
        {
            if (id != prenda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrendaExists(prenda.Id))
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
            return View(prenda);
        }

        // GET: Prenda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prenda == null)
            {
                return NotFound();
            }

            var prenda = await _context.Prenda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prenda == null)
            {
                return NotFound();
            }

            return View(prenda);
        }

        // POST: Prenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prenda == null)
            {
                return Problem("Entity set 'DBCrudContext.Prenda'  is null.");
            }
            var prenda = await _context.Prenda.FindAsync(id);
            if (prenda != null)
            {
                _context.Prenda.Remove(prenda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrendaExists(int id)
        {
          return (_context.Prenda?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult Search(string searchTerm)
        {
            var results = _context.Prenda
                .Where(p =>
                    p.Nombre.Contains(searchTerm) ||
                    p.Talla.Contains(searchTerm) ||
                    p.Precio.ToString().Contains(searchTerm) ||
                    p.Color.Contains(searchTerm) ||
                    p.Marca.Contains(searchTerm) ||
                    p.Estilo.Contains(searchTerm))
                .ToList();

            return View("Index", results);
        }


    }
}
