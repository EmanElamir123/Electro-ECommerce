using Electro_ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Electro_ECommerce.Controllers
{
    public class ProductController : Controller
    {

        //TechXpressDbContext db = new TechXpressDbContext();
        //var categ = db.Categories.ToList();
        private readonly TechXpressDbContext _context;

        public ProductController(TechXpressDbContext context)
        {
            _context = context;
        }
        // GET: CategoriesController
        public ActionResult Index()
        {
            var Products = _context.Products.ToList();
            return View(Products);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            var Products = _context.Products.Find(id);
            if (Products == null)
                return NotFound();

            return View(Products);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product Product)
        {

            if (ModelState.IsValid)
            {
                _context.Products.Add(Product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(Product);
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            var Product = _context.Products.Find(id);
            if (Product == null)
                return NotFound();

            return View(Product);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product Product)
        {

            if ((id != Product.ProductId)) return BadRequest();
            if (ModelState.IsValid)
            {
                _context.Products.Update(Product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(Product);
        }

        // GET: CategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            var Product = _context.Products.Find(id);
            if (Product == null)
                return NotFound();

            return View(Product);

        }

        // POST: CategoriesController/Delete/5
        [HttpPost, ActionName("delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            var Product = _context.Products.Find(id);
            if (Product == null) return NotFound();
            _context.Products.Remove(Product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}

