using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.CoreLayer.DTOs.Post;
using Weblog.CoreLayer.Utilities;

namespace Weblog.CoreLayer.Services.Post
{
    public interface IPostService
    {
        OperationResult CreatePost(CreatePostDto command);

        OperationResult EditPost(EditPostDto command);

        PostDto GetPostById(int postId);
        PostDto GetPostBySlug(string slug);

        bool IsSlugExist(string slug);  

        PostFilterDto GetPostFilterById(PostFilterParam filterParam);

        List<PostDto> GetRelatedPosts(int groupId);

		List<PostDto> GetPopularPosts();
	}
}
