using Microsoft.AspNetCore.Mvc;
using Weblog.CoreLayer.DTOs.Categories;
using Weblog.CoreLayer.Services.Categories;
using Weblog.CoreLayer.Utilities;
using Weblog.web.Areas.Admin.Models.Categories;

namespace Weblog.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategory());
        }
        [Route("/admin/category/add/{parentId?}")]
        public IActionResult Add(int?parentId)
        {
            return View();
        }
        [HttpPost("/admin/category/add/{parentId?}")]
        public IActionResult Add(int?parentId,CreateCategoryViewModel categoryViewModel) 
        {
            categoryViewModel.ParentId = parentId;

            var result=_categoryService.CreateCategory(categoryViewModel.MapToDto());

            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(categoryViewModel.Slug), result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id) 
        {
            var category=_categoryService.GetCategoryBy(id);
            if (category == null)
                return RedirectToAction("Index");
            var model = new EditCategoryViewModel()
            {
                Slug = category.Slug,
                MetaTag = category.MetaTag,
                MetaDescription = category.MetaDescription,
                Title = category.Title
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditCategoryViewModel editModel)
        {
            var result = _categoryService.EditCategory(new EditCategoryDto()
            {
                Slug = editModel.Slug,
                MetaTag = editModel.MetaTag,
                MetaDescription = editModel.MetaDescription,
                Title = editModel.Title,
                Id = id
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(editModel.Slug), result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }

        public IActionResult GetChildCategories(int parentId)
        {
            var category=_categoryService.GetChildCategories(parentId);

            return new JsonResult(category);
        }
    }
}
