using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPDonkeysProject.Data;
using ASPDonkeysProject.Models;

namespace ASPDonkeysProject.Controllers
{
    public class DonkeysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonkeysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Donkeys
        public async Task<IActionResult> Index()
        {
            return View(await _context.Donkey.ToListAsync());
        }

        public async Task<IActionResult> Add(int? id)
        {
            if (User == null)
                return NotFound();

            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var donk = _context?.Donkey?.Where(x => x.Id == id).FirstOrDefault();
                donk.IsWypozyczony = donk.IsWypozyczony ? false : true;
                if (donk == null)
                    return RedirectToAction(nameof(Index));

                try
                {
                    _context.Update(donk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonkeyExists(donk.Id))
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
            return RedirectToAction(nameof(Index));
        }

        // GET: Donkeys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donkey = await _context.Donkey
                .SingleOrDefaultAsync(m => m.Id == id);
            if (donkey == null)
            {
                return NotFound();
            }

            return View(donkey);
        }

        // GET: Donkeys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Donkeys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Value,Name,Age,Sex,IsPregnant")] Donkey donkey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donkey);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donkey);
        }

        // GET: Donkeys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donkey = await _context.Donkey.SingleOrDefaultAsync(m => m.Id == id);
            if (donkey == null)
            {
                return NotFound();
            }
            return View(donkey);
        }

        // POST: Donkeys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Value,Name,Age,Sex,IsPregnant")] Donkey donkey)
        {
            if (id != donkey.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donkey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonkeyExists(donkey.Id))
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
            return View(donkey);
        }

        // GET: Donkeys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donkey = await _context.Donkey
                .SingleOrDefaultAsync(m => m.Id == id);
            if (donkey == null)
            {
                return NotFound();
            }

            return View(donkey);
        }

        // POST: Donkeys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donkey = await _context.Donkey.SingleOrDefaultAsync(m => m.Id == id);
            _context.Donkey.Remove(donkey);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonkeyExists(int id)
        {
            return _context.Donkey.Any(e => e.Id == id);
        }
    }
}
