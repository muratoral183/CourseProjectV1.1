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

namespace CourseProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AddImageFile _addImageFile;
        public ProductController(ApplicationDbContext context, AddImageFile addImageFile)
        {
            _context = context;
            _addImageFile = addImageFile;   
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            List<Product> productList = await _context.Product.ToListAsync();

            return View(productList);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            // Dropdown list için seçenekleri oluşturun
            ViewBag.ProductTypes = new List<SelectListItem>
        {
            new SelectListItem { Value = "0", Text = "Yok" },
            new SelectListItem { Value = "1", Text = "Ambalaj" },
            new SelectListItem { Value = "2", Text = "Kalemlik" },
            new SelectListItem { Value = "3", Text = "Diğer" },
            new SelectListItem { Value = "5", Text = "Zımba" },
            new SelectListItem { Value = "6", Text = "Zımba Pimi" },
        };
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                // Dropdown list için seçenekleri oluşturun
                ViewBag.ProductTypes = new List<SelectListItem>
        {
            new SelectListItem { Value = "0", Text = "Yok" },
            new SelectListItem { Value = "1", Text = "Ambalaj" },
            new SelectListItem { Value = "2", Text = "Kalemlik" },
            new SelectListItem { Value = "3", Text = "Diğer" },
            new SelectListItem { Value = "5", Text = "Zımba" },
            new SelectListItem { Value = "6", Text = "Zımba Pimi" },
        };
                var filePath = await _addImageFile.UploadFileAsync(product.File, "category/page");
                product.ProductUrl = filePath;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Dropdown list için seçenekleri oluşturun
            ViewBag.ProductTypes = new List<SelectListItem>
        {
            new SelectListItem { Value = "0", Text = "Yok" },
            new SelectListItem { Value = "1", Text = "Ambalaj" },
            new SelectListItem { Value = "2", Text = "Kalemlik" },
            new SelectListItem { Value = "3", Text = "Diğer" },
            new SelectListItem { Value = "5", Text = "Zımba" },
            new SelectListItem { Value = "6", Text = "Zımba Pimi" },
        };

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var filePath = await _addImageFile.UploadFileAsync(product.File, "product/page");
                    if (filePath == null)
                    {
                        if (product.ProductUrl != null)
                        {
                            var oldCategoryName = product.ProductUrl;
                            product.ProductUrl = oldCategoryName;
                        }
                    }
                    else
                    {
                        product.ProductUrl = filePath;
                    }

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
