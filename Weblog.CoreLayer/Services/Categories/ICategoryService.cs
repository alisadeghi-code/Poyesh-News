using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.CoreLayer.DTOs.Categories;
using Weblog.CoreLayer.Utilities;

namespace Weblog.CoreLayer.Services.Categories
{
    public interface ICategoryService
    {
        OperationResult CreateCategory(CreateCategoryDto command);

        OperationResult EditCategory(EditCategoryDto command);

        List<CategoryDto> GetAllCategory();

        List<CategoryDto> GetChildCategories(int parentId);

        CategoryDto GetCategoryBy(int id);

        CategoryDto GetCategoryBy(string slug);

        bool IsSlugExist(string slug);
    }
}
