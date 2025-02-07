using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Electro_ECommerce.Controllers
{
    public class OrderDeteailsController : Controller
    {
        // GET: OrderDeteailsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderDeteailsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderDeteailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDeteailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderDeteailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderDeteailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderDeteailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderDeteailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
