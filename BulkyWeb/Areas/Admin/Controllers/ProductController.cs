using Bulky.DataAccess;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Product> products = _unitOfWork.Products.GetAll().ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.Products.Add(model);
            _unitOfWork.Save();
            TempData["success"] = "Product created successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var model = _unitOfWork.Products.Get(c => c.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model); ;
        }
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.Products.Update(model);
            _unitOfWork.Save();
            TempData["success"] = "Product updated successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var model = _unitOfWork.Products.Get(c => c.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model); ;
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var model = _unitOfWork.Products.Get(c => c.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            _unitOfWork.Products.Remove(model);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
