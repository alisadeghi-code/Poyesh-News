﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Weblog.CoreLayer.DTOs.Post;
using Weblog.CoreLayer.DTOs.Comment;
using Weblog.CoreLayer.Services.Comment;
using Weblog.CoreLayer.Services.Post;
using Weblog.CoreLayer.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Weblog.DataLayer.Context;
using Weblog.CoreLayer.Services.Categories;
using Weblog.CoreLayer.DTOs.Categories;

namespace Weblog.web.Pages
{
    public class PostModel : PageModel
    {
        private readonly IPostService _postService;
		private readonly ICommentService _commentService;
        private readonly ICategoryService _categoryService;

		public PostModel(IPostService postService,ICommentService commentService,ICategoryService categoryService)
		{
			_postService = postService;
            _commentService = commentService;
            _categoryService = categoryService;
		}

		

		

        public PostDto Post { get; set; }
        [BindProperty]
        [Required(ErrorMessage ="متن خود را وارد کنید")]
        public string Text { get; set; }
        [BindProperty]
        public int PostId { get; set; }
        public List<CategoryDto> category { get; set; }


        public List <CommentDto> Comments { get; set; }
		public List<PostDto> RelatedPost { get; set; }
		public IActionResult OnGet(string slug)
        {
            Post=_postService.GetPostBySlug(slug);
            if (Post == null)
            {
                return RedirectToAction("Error");
            }
			category = _categoryService.GetCategories();
			Comments = _commentService.GetPostComments(Post.PostId);
			RelatedPost = _postService.GetRelatedPosts(Post.SubCategoryId??Post.CategoryId);
            _postService.IncreaseVisit(Post.PostId);
			return Page();
        }

        public IActionResult OnPost(string slug) 
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToPage("Post",new  {slug });
            if (!ModelState.IsValid) 
            {
				Post = _postService.GetPostBySlug(slug);
				Comments = _commentService.GetPostComments(Post.PostId);
				RelatedPost = _postService.GetRelatedPosts(Post.SubCategoryId ?? Post.CategoryId);
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
