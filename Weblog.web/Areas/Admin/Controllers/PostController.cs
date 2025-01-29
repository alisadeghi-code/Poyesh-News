using Weblog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Weblog.CoreLayer.DTOs.Post;
using Weblog.CoreLayer.Services.Post;
using Weblog.web.Areas.Admin.Models.Posts;

namespace Weblog.web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class PostController : Controller
	{
		private readonly IPostService _postservice;

        public PostController(IPostService postservice)
        {
            _postservice = postservice;
        }

        public IActionResult Index(int pageId=1,string title="",string CategorySlug="")
		{
			var param = new PostFilterParam
			{
				CategorySlug = CategorySlug,
				PageId = pageId,
				Title = title,
				Take = 12
			};
			var model = _postservice.GetPostFilterById(param);
			return View(model);
		}
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CreatePostViewModel postViewModel)
        {
            if (!ModelState.IsValid) 
            {
                return View();
            }

            var result = _postservice.CreatePost(new CreatePostDto()
            {
                Title=postViewModel.Title,
                Description=postViewModel.Description,
                ImageFile=postViewModel.ImageFile,
                SubCategoryId=postViewModel.SubCategoryId == 0 ? null : postViewModel.SubCategoryId,
                Slug=postViewModel.Slug,
                CategoryId=postViewModel.CategoryId,
                UserId=User.GetUserId()

            });

            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(postViewModel.Slug), result.Message);
                return View(postViewModel);
            }

           return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var post=_postservice.GetPostById(id);
            if (post == null)
                RedirectToAction("Index");

            var model = new EditPostViewModel
            {
                CategoryId=post.CategoryId,
                Title=post.Title,
                Description=post.Description,
                ImageFile=post.ImageFile,
                SubCategoryId=post.SubCategoryId,
                Slug=post.Slug,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,EditPostViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = _postservice.EditPost(new EditPostDto()
            {
                Title = editViewModel.Title,
                Description = editViewModel.Description,
                ImageFile = editViewModel.ImageFile,
                SubCategoryId = editViewModel.SubCategoryId==0?null : editViewModel.SubCategoryId,
                Slug = editViewModel.Slug,
                CategoryId = editViewModel.CategoryId,
                PostId=id

            });

            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(editViewModel.Slug), result.Message);
                return View(editViewModel);
            }

            return RedirectToAction("Index");
        }
    }
}
