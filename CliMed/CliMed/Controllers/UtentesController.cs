using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CliMed.Data;
using CliMed.Models;

namespace CliMed.Controllers
{
    public class UtentesController : Controller
    {
        private readonly CliMedBD db;

        public UtentesController(CliMedBD context)
        {
            db = context;
        }

        // GET: Utentes
        public async Task<IActionResult> Index()
        {
            return View(await db.Utentes.ToListAsync());
        }

        // GET: Utentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utentes = await db.Utentes
                .FirstOrDefaultAsync(m => m.IdUtente == id);
            if (utentes == null)
            {
                return NotFound();
            }

            return View(utentes);
        }

        // GET: Utentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUtente,Nome,DataNasc,Contacto,Mail,Morada,CC,NIF")] Utentes utentes)
        {
            if (ModelState.IsValid)
            {
                db.Add(utentes);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utentes);
        }

        // GET: Utentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utentes = await db.Utentes.FindAsync(id);
            if (utentes == null)
            {
                return NotFound();
            }
            return View(utentes);
        }

        // POST: Utentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUtente,Nome,DataNasc,Contacto,Mail,Morada,CC,NIF")] Utentes utentes)
        {
            if (id != utentes.IdUtente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(utentes);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtentesExists(utentes.IdUtente))
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
            return View(utentes);
        }

        // GET: Utentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utente = await db.Utentes
                .FirstOrDefaultAsync(m => m.IdUtente == id);
            if (utente == null)
            {
                return NotFound();
            }

            return View(utente);
        }

        // POST: Utentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utentes = await db.Utentes.FindAsync(id);
            db.Utentes.Remove(utentes);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtentesExists(int id)
        {
            return db.Utentes.Any(e => e.IdUtente == id);
        }
    }
}
