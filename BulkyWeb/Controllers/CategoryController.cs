using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _contex;

        public CategoryController(ApplicationDbContext contex)
        {
            _contex = contex;
        }

        public IActionResult Index()
        {
            List<Category> categories = _contex.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category model)
        {
            if (!ModelState.IsValid) 
                return View(model);
          
            _contex.Categories.Add(model);
            _contex.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var model = _contex.Categories.SingleOrDefault(c => c.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model); ;
        }
        [HttpPost]
        public IActionResult Edit(Category model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _contex.Categories.Update(model);
            _contex.SaveChanges();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var model = _contex.Categories.SingleOrDefault(c => c.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model); ;
        }
        [HttpPost , ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var model = _contex.Categories.SingleOrDefault(c => c.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            _contex.Categories.Remove(model);
            _contex.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
