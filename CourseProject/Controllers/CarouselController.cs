using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourseProject.DAL.Context;
using CourseProject.DAL.Entity;
using CourseProject.Helper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CourseProject.Controllers
{
    public class CarouselController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AddImageFile _addImageFile;

        public CarouselController(ApplicationDbContext context, AddImageFile addImageFile)
        {
            _context = context;
            _addImageFile = addImageFile;
        }

        // GET: Carousel
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carousel.ToListAsync());
        }

        // GET: Carousel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carousel = await _context.Carousel
                .FirstOrDefaultAsync(m => m.CarouselId == id);
            if (carousel == null)
            {
                return NotFound();
            }

            return View(carousel);
        }

        // GET: Carousel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carousel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Carousel carousel)
        {
            if (ModelState.IsValid)
            {
                var filePath = await _addImageFile.UploadFileAsync(carousel.File, "img/page");
                carousel.CarouselUrl = filePath;
                _context.Add(carousel);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carousel);
        }

        // GET: Carousel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carousel = await _context.Carousel.FindAsync(id);
            if (carousel == null)
            {
                return NotFound();
            }
            return View(carousel);
        }

        // POST: Carousel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Carousel carousel)
        {
            if (id != carousel.CarouselId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                 
                 
                   

                    
                    var filePath = await _addImageFile.UploadFileAsync(carousel.File, "img/page");
                    if (filePath == null)
                    {
                        if (carousel.CarouselUrl != null)
                        {
                            var oldCategoryName = carousel.CarouselUrl;
                            carousel.CarouselUrl = oldCategoryName;
                        }
                    }
                    else
                    {
                        carousel.CarouselUrl = filePath;
                    }
                    _context.Update(carousel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarouselExists(carousel.CarouselId))
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
            return View(carousel);
        }

        // GET: Carousel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carousel = await _context.Carousel
                .FirstOrDefaultAsync(m => m.CarouselId == id);
            if (carousel == null)
            {
                return NotFound();
            }

            return View(carousel);
        }

        // POST: Carousel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carousel = await _context.Carousel.FindAsync(id);
            if (carousel != null)
            {
                _context.Carousel.Remove(carousel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarouselExists(int id)
        {
            return _context.Carousel.Any(e => e.CarouselId == id);
        }
    }
}
