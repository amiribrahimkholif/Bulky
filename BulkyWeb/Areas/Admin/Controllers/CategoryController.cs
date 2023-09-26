using Bulky.DataAccess;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Category> categories = _unitOfWork.Categories.GetAll().ToList();
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

            _unitOfWork.Categories.Add(model);
            _unitOfWork.Save();
            TempData["success"] = "Category created successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var model = _unitOfWork.Categories.Get(c => c.Id == id);
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

            _unitOfWork.Categories.Update(model);
            _unitOfWork.Save();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var model = _unitOfWork.Categories.Get(c => c.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model); ;
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var model = _unitOfWork.Categories.Get(c => c.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            _unitOfWork.Categories.Remove(model);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
