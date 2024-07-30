using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourseProject.DAL.Context;
using CourseProject.DAL.Entity;

namespace CourseProject.Controllers
{
    public class CustomBannerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomBannerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomBanner
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomBanner.ToListAsync());
        }

        // GET: CustomBanner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customBanner = await _context.CustomBanner
                .FirstOrDefaultAsync(m => m.CustomBannerId == id);
            if (customBanner == null)
            {
                return NotFound();
            }

            return View(customBanner);
        }

        // GET: CustomBanner/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomBanner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomBannerId,CustomBannerUrl,Title,Description,Link,BannnerStatus")] CustomBanner customBanner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customBanner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customBanner);
        }

        // GET: CustomBanner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customBanner = await _context.CustomBanner.FindAsync(id);
            if (customBanner == null)
            {
                return NotFound();
            }
            return View(customBanner);
        }

        // POST: CustomBanner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomBannerId,CustomBannerUrl,Title,Description,Link,BannnerStatus")] CustomBanner customBanner)
        {
            if (id != customBanner.CustomBannerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customBanner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomBannerExists(customBanner.CustomBannerId))
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
            return View(customBanner);
        }

        // GET: CustomBanner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customBanner = await _context.CustomBanner
                .FirstOrDefaultAsync(m => m.CustomBannerId == id);
            if (customBanner == null)
            {
                return NotFound();
            }

            return View(customBanner);
        }

        // POST: CustomBanner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customBanner = await _context.CustomBanner.FindAsync(id);
            if (customBanner != null)
            {
                _context.CustomBanner.Remove(customBanner);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomBannerExists(int id)
        {
            return _context.CustomBanner.Any(e => e.CustomBannerId == id);
        }
    }
}
