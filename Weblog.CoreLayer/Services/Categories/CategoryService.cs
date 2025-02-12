using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.CoreLayer.DTOs.Categories;
using Weblog.CoreLayer.Utilities;
using Weblog.DataLayer.Context;
using Weblog.DataLayer.Entities;
using Weblog.CoreLayer.Mappers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Weblog.CoreLayer.Services.Categories
{

    public class CategoryService : ICategoryService
    {
        private readonly BlogContext _context;

        public CategoryService(BlogContext context)
        {
            _context = context;
        }

        public OperationResult CreateCategory(CreateCategoryDto command)
        {
                if (IsSlugExist (command.Slug.ToSlug())||command.Slug==null)
                return OperationResult.Error( "اسلاگ صحیح را وارد کنید");

           var category=CategoryMapper.MapCreateDtoToCategory(command);

            
            _context.Categories.Add(category);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult EditCategory(EditCategoryDto command)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == command.Id);
            if(category==null)
                return OperationResult.NotFound();


            if(command.Slug.ToSlug()!=category.Slug)
                if (IsSlugExist(command.Slug))
                    return OperationResult.Error("این اسلاگ قبلا استفاده شده است");

                

            category=CategoryMapper.MapEditDtoToCategory(command, category);


            _context.Update(category);
            _context.SaveChanges();
            return OperationResult.Success();
           
        }

        public List<CategoryDto> GetAllCategory()
        {
            return _context.Categories.Select(Category=>CategoryMapper.Map(Category)).ToList();
        }

		public List<CategoryDto> GetCategories()
		{
			return _context.Categories
                .Take(5)
                .Select(Category => CategoryMapper.Map(Category)).ToList();
		}

		public CategoryDto GetCategoryBy(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if(category==null)
                return null;
            return CategoryMapper.Map(category);
        }

        public CategoryDto GetCategoryBy(string slug)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Slug == slug);
            if (category == null)
                return null;
            return CategoryMapper.Map(category);
        }

        public List<CategoryDto> GetChildCategories(int parentId)
        {
            return _context.Categories.Where(r=>r.ParentId==parentId).Select(Category => CategoryMapper.Map(Category)).ToList();
        }

        public bool IsSlugExist(string slug)
        {
            return _context.Categories.Any(c => c.Slug == slug.ToSlug());
        }
    }
}
