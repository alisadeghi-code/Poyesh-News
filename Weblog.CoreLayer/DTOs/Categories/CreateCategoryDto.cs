using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weblog.CoreLayer.DTOs.Categories
{
    public class CreateCategoryDto
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage ="باید عنوان را وارد کنید")]
        public string Title { get; set; }

        
        public string Slug { get; set; }

        [Display(Name = "MetaTag(با استفاده از - از بکدیگر جدا بکنید)")]
        public string MetaTag { get; set; }

        public string MetaDescription { get; set; }

        public int? ParentId { get; set; }
    }

    public class EditCategoryDto : CreateCategoryDto
    {
        public int Id { get; set; }

    }

    public class CategoryDto: EditCategoryDto
    {

    }
}
