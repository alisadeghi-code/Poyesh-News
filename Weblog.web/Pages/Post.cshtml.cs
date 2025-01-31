using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Weblog.CoreLayer.DTOs.Post;
using Weblog.CoreLayer.Services.Post;

namespace Weblog.web.Pages
{
    public class PostModel : PageModel
    {
        private readonly IPostService _postService;

        public PostModel(IPostService postService)
        {
            _postService = postService;
        }

        public PostDto Post { get; set; }
        public IActionResult OnGet(string slug)
        {
            Post=_postService.GetPostBySlug(slug);
            if (Post == null)
            {
                return RedirectToAction("Error");
            }
            return Page();
        }
    }
}
