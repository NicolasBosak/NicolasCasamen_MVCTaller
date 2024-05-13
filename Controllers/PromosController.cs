﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NicolasCasamen_MVCTaller.Data;
using NicolasCasamen_MVCTaller.Models;

namespace NicolasCasamen_MVCTaller.Controllers
{
    public class PromosController : Controller
    {
        private readonly NicolasCasamen_MVCTallerContext _context;

        public PromosController(NicolasCasamen_MVCTallerContext context)
        {
            _context = context;
        }

        // GET: Promos
        public async Task<IActionResult> Index()
        {
            var nicolasCasamen_MVCTallerContext = _context.Promo.Include(p => p.Burger);
            return View(await nicolasCasamen_MVCTallerContext.ToListAsync());
        }

        // GET: Promos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Promo == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo
                .Include(p => p.Burger)
                .FirstOrDefaultAsync(m => m.PromoId == id);
            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        // GET: Promos/Create
        public IActionResult Create()
        {
            ViewData["BurgerId"] = new SelectList(_context.Burger, "BurgerId", "Name");
            return View();
        }

        // POST: Promos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromoId,PromoDescripcion,FechaPromocion,BurgerId")] Promo promo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurgerId"] = new SelectList(_context.Burger, "BurgerId", "Name", promo.BurgerId);
            return View(promo);
        }

        // GET: Promos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Promo == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo.FindAsync(id);
            if (promo == null)
            {
                return NotFound();
            }
            ViewData["BurgerId"] = new SelectList(_context.Burger, "BurgerId", "Name", promo.BurgerId);
            return View(promo);
        }

        // POST: Promos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromoId,PromoDescripcion,FechaPromocion,BurgerId")] Promo promo)
        {
            if (id != promo.PromoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromoExists(promo.PromoId))
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
            ViewData["BurgerId"] = new SelectList(_context.Burger, "BurgerId", "Name", promo.BurgerId);
            return View(promo);
        }

        // GET: Promos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Promo == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo
                .Include(p => p.Burger)
                .FirstOrDefaultAsync(m => m.PromoId == id);
            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        // POST: Promos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Promo == null)
            {
                return Problem("Entity set 'NicolasCasamen_MVCTallerContext.Promo'  is null.");
            }
            var promo = await _context.Promo.FindAsync(id);
            if (promo != null)
            {
                _context.Promo.Remove(promo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromoExists(int id)
        {
          return (_context.Promo?.Any(e => e.PromoId == id)).GetValueOrDefault();
        }
    }
}
