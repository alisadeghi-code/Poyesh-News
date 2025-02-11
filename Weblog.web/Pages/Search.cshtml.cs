using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Xml.Linq;
using Weblog.CoreLayer.DTOs.Post;
using Weblog.CoreLayer.Services.Post;

namespace Weblog.web.Pages
{
    public class SearchModel : PageModel
    {
        private readonly IPostService _postService;

		public SearchModel(IPostService postService)
		{
			_postService = postService;
		}
		public PostDto Post { get; set; }
		public List<PostDto> LatestPost { get; set; }
		public PostFilterDto PostFilter { get; set; }
		public IActionResult OnGet(int pageId=1,string categorySlug=null,string q = null)
        {

            PostFilter = _postService.GetPostFilterById(new PostFilterParam()
            {
                CategorySlug = categorySlug,
                PageId = pageId,
                Take = 2,
                Title = q
            }) ;

			LatestPost = _postService.GetLatestposts();

			return Page();
		}

		public IActionResult OnGetPagination(int pageId = 1, string categorySlug = null, string q = null)
		{

			var model = _postService.GetPostFilterById(new PostFilterParam()
			{
				CategorySlug = categorySlug,
				PageId = pageId,
				Take = 2,
				Title = q
			});
			return Partial("_SearchView", model);
		}

	}
}
