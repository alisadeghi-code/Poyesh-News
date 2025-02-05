using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Weblog.CoreLayer.DTOs.Post;
using Weblog.CoreLayer.DTOs.Comment;
using Weblog.CoreLayer.Services.Comment;
using Weblog.CoreLayer.Services.Post;
using Weblog.CoreLayer.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Weblog.web.Pages
{
    public class PostModel : PageModel
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;

		public PostModel(ICommentService commentService)
		{
			_commentService = commentService;
		}

		public PostModel(IPostService postService)
        {
            _postService = postService;
        }

        public PostDto Post { get; set; }
        [BindProperty]
        [Required(ErrorMessage ="متن خود را وارد کنید")]
        public string Text { get; set; }
        [BindProperty]
        public int PostId { get; set; }


        public List <CommentDto> Comments { get; set; }
        public IActionResult OnGet(string slug)
        {
            Post=_postService.GetPostBySlug(slug);
            if (Post == null)
            {
                return RedirectToAction("Error");
            }

            Comments = _commentService.GetPostComments(Post.PostId);
            return Page();
        }

        public IActionResult OnPost(string slug) 
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToPage("Auth/SignIn");
            if (!ModelState.IsValid) 
            {
                Post = _postService.GetPostBySlug(slug);
                return Page();
            }

            _commentService.CreateComment(new CreateCommentDto()
            {
                UserId = User.GetUserId(),
                PostId = PostId,
                Text = Text,
            });
			return RedirectToPage("Post",new {slug});
		}
    }
}
