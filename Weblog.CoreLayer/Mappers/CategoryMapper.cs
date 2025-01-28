using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.CoreLayer.DTOs.Categories;
using Weblog.CoreLayer.DTOs.Post;
using Weblog.CoreLayer.Utilities;
using Weblog.DataLayer.Entities;

namespace Weblog.CoreLayer.Mappers
{
    public class CategoryMapper
    {
        public static CategoryDto Map(Category category)
        {
            return new CategoryDto()
            {
                Title = category.Title,
                Slug = category.Slug,
                ParentId = category.ParentId,
                MetaDescription = category.MetaDescription,
                MetaTag = category.MetaTag,
                Id = category.Id,

            };
        }

        public static Category MapCreateDtoToCategory(CreateCategoryDto category)
        {

                return new Category()
            {
               Title=category.Title,
               Slug=category.Slug.ToSlug(),
               ParentId = category.ParentId,
               MetaDescription = category.MetaDescription,
               MetaTag = category.MetaTag,
               IsDelete=false
            };

        }

        public static Category MapEditDtoToCategory(EditCategoryDto editCategory, Category category)
        {
          category.Title = editCategory.Title;
            category.Slug = editCategory.Slug.ToSlug();
            category.MetaDescription = editCategory.MetaDescription;
            category.MetaTag = editCategory.MetaTag;
            return category;
        }
    }
}
