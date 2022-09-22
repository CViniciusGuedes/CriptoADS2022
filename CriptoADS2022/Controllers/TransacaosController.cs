using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CriptoADS2022.Models;

namespace CriptoADS2022.Controllers
{
    public class TransacaosController : Controller
    {
        private readonly Contexto _context;

        public TransacaosController(Contexto context)
        {
            _context = context;
        }

        // GET: Transacaos
        public async Task<IActionResult> Index()
        {
              return View(await _context.transacoes.ToListAsync());
        }

        // GET: Transacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.transacoes == null)
            {
                return NotFound();
            }

            var transacao = await _context.transacoes
                .FirstOrDefaultAsync(m => m.id == id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // GET: Transacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,data,quantidade,valor,operacao")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transacao);
        }

        // GET: Transacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.transacoes == null)
            {
                return NotFound();
            }

            var transacao = await _context.transacoes.FindAsync(id);
            if (transacao == null)
            {
                return NotFound();
            }
            return View(transacao);
        }

        // POST: Transacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,data,quantidade,valor,operacao")] Transacao transacao)
        {
            if (id != transacao.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransacaoExists(transacao.id))
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
            return View(transacao);
        }

        // GET: Transacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.transacoes == null)
            {
                return NotFound();
            }

            var transacao = await _context.transacoes
                .FirstOrDefaultAsync(m => m.id == id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // POST: Transacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.transacoes == null)
            {
                return Problem("Entity set 'Contexto.transacoes'  is null.");
            }
            var transacao = await _context.transacoes.FindAsync(id);
            if (transacao != null)
            {
                _context.transacoes.Remove(transacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransacaoExists(int id)
        {
          return _context.transacoes.Any(e => e.id == id);
        }
    }
}
