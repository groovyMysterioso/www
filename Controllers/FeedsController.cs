using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using www.Data;
using www.Models;

namespace www.Controllers
{
    public class FeedsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Feeds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Feed.ToListAsync());
        }

        // GET: Feeds/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feed = await _context.Feed
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feed == null)
            {
                return NotFound();
            }

            return View(feed);
        }

        // GET: Feeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Feeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserID,Content")] Feed feed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feed);
        }

        // GET: Feeds/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feed = await _context.Feed.FindAsync(id);
            if (feed == null)
            {
                return NotFound();
            }
            return View(feed);
        }

        // POST: Feeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,UserID,Content")] Feed feed)
        {
            if (id != feed.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedExists(feed.Id))
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
            return View(feed);
        }

        // GET: Feeds/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feed = await _context.Feed
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feed == null)
            {
                return NotFound();
            }

            return View(feed);
        }

        // POST: Feeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var feed = await _context.Feed.FindAsync(id);
            _context.Feed.Remove(feed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedExists(string id)
        {
            return _context.Feed.Any(e => e.Id == id);
        }
    }
}
