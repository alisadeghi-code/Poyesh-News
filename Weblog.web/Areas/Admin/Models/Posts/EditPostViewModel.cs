using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Weblog.web.Areas.Admin.Models.Posts
{
    public class EditPostViewModel
    {
        [Display(Name = "انتخاب دسته بندی")]
        [Required(ErrorMessage = "لطفا دسته بندی را انتخاب کنید")]
        public int CategoryId { get; set; }
        [Display(Name = "انتخاب زیردسته بندی")]
        [Required(ErrorMessage = "لطفا دسته بندی را انتخاب کنید")]
        public int? SubCategoryId { get; set; }
        [Display(Name = " عنوان ")]
        [Required(ErrorMessage = " عنوان را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = " توضیحات")]
        [Required(ErrorMessage = " لطفا توضیحات را را پر کنید")]
        [UIHint("Ckeditor4")]
        public string Description { get; set; }
        [Display(Name = " اسلاگ")]
        [Required(ErrorMessage = "لطفا اسلاگ را وارد کنید")]
        public string Slug { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
