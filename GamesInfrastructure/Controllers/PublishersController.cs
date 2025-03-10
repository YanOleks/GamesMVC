﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamesDomain.Model;
using GamesInfrastructure;

namespace GamesInfrastructure.Controllers
{
    public class PublishersController : Controller
    {
        private readonly Istp1Context _context;

        public PublishersController(Istp1Context context)
        {
            _context = context;
        }

        // GET: Publishers
        public async Task<IActionResult> Index(int? id, string? name)
        {
            if (id == null)
            {
                var publisherByCountry = _context.Publishers.Include(p => p.CountryOfOriginNavigation);
                return View(await publisherByCountry.ToListAsync());
            }
            else
            {
                ViewBag.CountryId = id;
                ViewBag.CountryName = name;

                var publisherByCountry = _context.Publishers.Where(p => p.CountryOfOrigin == id).Include(p => p.CountryOfOriginNavigation);
                return View(await publisherByCountry.ToListAsync());
            }            
        }

        // GET: Publishers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .Include(p => p.CountryOfOriginNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publisher == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Games", publisher);
        }

        // GET: Publishers/Create
        public IActionResult Create()
        {
            ViewData["CountryOfOrigin"] = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        // POST: Publishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CountryOfOrigin")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publisher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryOfOrigin"] = new SelectList(_context.Countries, "Id", "Name", publisher.CountryOfOrigin);
            return View(publisher);
        }

        // GET: Publishers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }
            ViewData["CountryOfOrigin"] = new SelectList(_context.Countries, "Id", "Name", publisher.CountryOfOrigin);
            return View(publisher);
        }

        // POST: Publishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CountryOfOrigin")] Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publisher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublisherExists(publisher.Id))
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
            ViewData["CountryOfOrigin"] = new SelectList(_context.Countries, "Id", "Name", publisher.CountryOfOrigin);
            return View(publisher);
        }

        // GET: Publishers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .Include(p => p.CountryOfOriginNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher != null)
            {
                var games = _context.Games.Where(g => g.PublisherId == id);
                var gameIds = games.Select(g => g.Id);
                var stocks = _context.Stocks.Where(s => gameIds.Contains(s.GameId));
                var reviews = _context.Reviews.Where(r => gameIds.Contains(r.GameId));

                _context.Reviews.RemoveRange(reviews);
                _context.Stocks.RemoveRange(stocks);
                _context.Games.RemoveRange(games);
                _context.Publishers.Remove(publisher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublisherExists(int id)
        {
            return _context.Publishers.Any(e => e.Id == id);
        }
    }
}
