using BookShopMVC.DataAccess.Repository.IRepository;
using BookShopMVC.Model;
using BookShopMVC.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShopMVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	//[Authorize(Roles = StaticDetails.Role_Admin)]
	public class CategoryController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public CategoryController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
			return View(objCategoryList);
		}

		public IActionResult Create()
		{
			return View();
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            string newName = category.Name!.Trim().ToLower();

            // Kiểm tra Name trùng
            bool isNameDuplicate = _unitOfWork.Category
                .GetAll()
                .Any(c => c.Name!.Trim().ToLower() == newName);

            if (isNameDuplicate)
            {
                ModelState.AddModelError("Name", "Tên danh mục đã tồn tại");
            }

            // Kiểm tra DisplayOrder trùng
            bool isDisplayOrderDuplicate = _unitOfWork.Category
                .GetAll()
                .Any(c => c.DisplayOrder == category.DisplayOrder);

            if (isDisplayOrderDuplicate)
            {
                ModelState.AddModelError("DisplayOrder", "Thứ tự hiển thị đã tồn tại");
            }

            if (!ModelState.IsValid)
            {
                return View(category); // giữ dữ liệu nhập
            }

            _unitOfWork.Category.Add(category);
            _unitOfWork.Save();
            TempData["success"] = "Danh mục đã được tạo thành công!";
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _unitOfWork.Category.GetById(id); // dùng GetById
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            string newName = category.Name!.Trim().ToLower();

            // kiểm tra Name trùng, loại trừ chính nó
            bool isNameDuplicate = _unitOfWork.Category.GetAll()
                .Any(c => c.Id != category.Id && c.Name!.Trim().ToLower() == newName);

            if (isNameDuplicate)
            {
                ModelState.AddModelError("Name", "Tên danh mục đã tồn tại");
            }

            // kiểm tra DisplayOrder trùng
            bool isDisplayOrderDuplicate = _unitOfWork.Category.GetAll()
                .Any(c => c.Id != category.Id && c.DisplayOrder == category.DisplayOrder);

            if (isDisplayOrderDuplicate)
            {
                ModelState.AddModelError("DisplayOrder", "Thứ tự hiển thị đã tồn tại");
            }

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _unitOfWork.Category.Update(category);
            _unitOfWork.Save();
            TempData["success"] = "Danh mục đã được cập nhật thành công!";
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			Category? category = _unitOfWork.Category.GetById((int)id);

			if (category == null)
			{
				return NotFound();
			}

			return View(category);
		}

		[HttpPost]
		public IActionResult Delete(Category category)
		{
			Category? categoryFromDb = _unitOfWork.Category.GetById(category.Id);
			if (categoryFromDb == null)
			{
				return NotFound();
			}
			_unitOfWork.Category.Remove(categoryFromDb);
			_unitOfWork.Save();
			TempData["success"] = "Danh mục đã được xóa thành công!";
			return RedirectToAction("Index", "Category");
		}
	}
}
