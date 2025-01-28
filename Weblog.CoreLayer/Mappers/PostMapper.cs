using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.CoreLayer.DTOs.Post;
using Weblog.DataLayer.Entities;

namespace Weblog.CoreLayer.Mappers
{
    public class PostMapper
    {
        public static Post MapCreateDtoToPost(CreatePostDto post) 
        {
            return new Post()
            {
                Description = post.Description,
                UserId = post.UserId,
                CategoryId = post.CategoryId,
                Title = post.Title,
                Slug = post.Slug,
                IsDelete=false,
                Visit=0,
                SubCategoryId=post.SubCategoryId,
            };
        }

        public static Post MapEditDtoToPost(EditPostDto editpost,Post post)
        {
            post.Description = editpost.Description;
            post.CategoryId = editpost.CategoryId;
            post.Title = editpost.Title;
            post.Slug = editpost.Slug;
            post.SubCategoryId = editpost.SubCategoryId;
            return post;
        }

        public static PostDto MapToDto(Post post)
        {
            return new PostDto()
            {
                Description = post.Description,
                UserId = post.UserId,
                CategoryId = post.CategoryId,
                Title = post.Title,
                Slug = post.Slug,
                Visit = 0,
                Category = CategoryMapper.Map(post.Category),
                CreationDate = post.CreationDate,
                ImageName = post.ImageName,
                PostId = post.Id,
                SubCategoryId = post.SubCategoryId,
                SubCategory = post.SubCategoryId == null ? null : CategoryMapper.Map(post.SubCategory),
                

            };
        }
    }
}
