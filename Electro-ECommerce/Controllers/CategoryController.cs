using Electro_ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;




namespace Electro_ECommerce.Controllers
{
    public class CategoriesController : Controller
    {

        //TechXpressDbContext db = new TechXpressDbContext(); 
        private readonly TechXpressDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoriesController(TechXpressDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

       

        // GET: CategoriesController
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            var categories = _context.Categories.Find(id);
            if (categories == null)
                return NotFound();

            return View(categories);
        }
       
        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(fileStream);
                    }

                    
                    category.ImageUrl = "/img/" + uniqueFileName;
                }

                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    

    // GET: CategoriesController/Edit/5
    public ActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {

            if ((id != category.CategoryId)) return BadRequest();
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: CategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
                return NotFound();

            return View(category);

        }

        // POST: CategoriesController/Delete/5
        [HttpPost, ActionName("delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        internal RedirectToActionResult Create(Category newCategory)
        {
            throw new NotImplementedException();
        }
    }
}
