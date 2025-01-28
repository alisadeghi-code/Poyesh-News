using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Weblog.web.Areas.Admin.Models.Posts
{
    public class CreatePostViewModel
    {
 
        [Display(Name = "انتخاب دسته بندی")]
        [Required(ErrorMessage = "لطفا دسته بندی را انتخاب کنید")]
        public int CategoryId { get; set; }
        [Display(Name = "انتخاب زیر دسته بندی")]
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
        [Display(Name = "عکس ")]
        [Required(ErrorMessage = "لطفا عکس را آپلود کنید")]
        public IFormFile ImageFile { get; set; }
    }
}
