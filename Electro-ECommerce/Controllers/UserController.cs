using Electro_ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Electro_ECommerce.Controllers
{
    public class UserController : Controller
    {

        //TechXpressDbContext db = new TechXpressDbContext();
        //var categ = db.Categories.ToList();
        private readonly TechXpressDbContext _context;

        public UserController(TechXpressDbContext context)
        {
            _context = context;
        }
        // GET: CategoriesController
        public ActionResult Index()
        {
            var Users = _context.Users.ToList();
            return View(Users);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            var User = _context.Users.Find(id);
            if (User== null)
                return NotFound();

            return View(User);
        }
     
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User User)
        {
            
            if (ModelState.IsValid)
            {
                _context.Users.Add(User);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(User);
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            var User = _context.Users.Find(id);
            if (User == null)
                return NotFound();

            return View(User);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User User)
        {

            if ((id != User.UserId)) return BadRequest();
            if (ModelState.IsValid)
            {
                _context.Users.Update(User);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(User);
        }

        // GET: CategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            var User = _context.Users.Find(id);
            if (User == null)
                return NotFound();

            return View(User);

        }

        // POST: CategoriesController/Delete/5
        [HttpPost, ActionName("delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            var User = _context.Users.Find(id);
            if (User == null) return NotFound();
            _context.Users.Remove(User);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}

