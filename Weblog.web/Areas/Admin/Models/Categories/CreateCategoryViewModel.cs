using System.ComponentModel.DataAnnotations;
using Weblog.CoreLayer.DTOs.Categories;

namespace Weblog.web.Areas.Admin.Models.Categories
{
    public class CreateCategoryViewModel
    {

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "باید عنوان را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "اسلاگ")]
        [Required(ErrorMessage = "باید اسلاگ را وارد کنید")]
        public string Slug { get; set; }

        [Display(Name = "MetaTag(با استفاده از - از بکدیگر جدا بکنید)")]
        public string MetaTag { get; set; }

        [DataType(DataType.MultilineText)]
        public string MetaDescription { get; set; }

        public int? ParentId { get; set; }

        public CreateCategoryDto MapToDto()
        {
            return new CreateCategoryDto()
            {
                Title = Title,
                MetaDescription = MetaDescription,
                Slug = Slug,
                ParentId = ParentId,
                MetaTag = MetaTag
            };
        }

    }
}
