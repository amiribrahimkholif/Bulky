using Bulky.DataAccess;
using Bulky.DataAccess.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            List<Category> categories = _categoryRepo.GetAll().ToList();
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

            _categoryRepo.Add(model);
            _categoryRepo.Save();
            TempData["success"] = "Category created successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var model = _categoryRepo.Get(c => c.Id == id);
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

            _categoryRepo.Update(model);
            _categoryRepo.Save();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var model = _categoryRepo.Get(c => c.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model); ;
        }
        [HttpPost , ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var model = _categoryRepo.Get(c => c.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            _categoryRepo.Remove(model);
            _categoryRepo.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
