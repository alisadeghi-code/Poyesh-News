using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Weblog.CoreLayer.DTOs.Post;
using Weblog.CoreLayer.Mappers;
using Weblog.CoreLayer.Services.FileManager;
using Weblog.CoreLayer.Utilities;
using Weblog.DataLayer.Context;
using Weblog.DataLayer.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Weblog.CoreLayer.Services.Post
{
    public class PostService : IPostService
    {
        private readonly BlogContext _context;
        private readonly IFileManager _filemanager;
        public PostService(BlogContext context,IFileManager filemanager)
        {
            _filemanager = filemanager;
            _context = context;
        }

        public OperationResult CreatePost(CreatePostDto command)
        {
            if(command.ImageFile==null)
                return OperationResult.Error();

            if (IsSlugExist(command.Slug.ToSlug()))
                return OperationResult.Error("این اسلاگ قبلا استفاده شده است");

            
            var post = PostMapper.MapCreateDtoToPost(command);
            post.ImageName = _filemanager.SaveFile(command.ImageFile, Directories.PostImage);
            _context.Posts.Add(post);
            _context.SaveChanges();
            return OperationResult.Success();

           
        }

        public OperationResult EditPost(EditPostDto command)
        {
            
            var post=_context.Posts.FirstOrDefault(c=>c.Id==command.PostId);
            if (post == null) 
                return OperationResult.NotFound();
            var oldImage = post.ImageName;
            if (command.ImageFile!=null)
                post.ImageName=_filemanager.SaveFile(command.ImageFile,Directories.PostImage);

            if (command.Slug.ToSlug() != post.Slug)
                if (IsSlugExist(command.Slug))
                    return OperationResult.Error("این اسلاگ قبلا استفاده شده است");

            post = PostMapper.MapEditDtoToPost(command, post);
            _context.Update(post);
            _context.SaveChanges();
            if (command.ImageFile != null)
                _filemanager.DeleteFile(oldImage, Directories.PostImage);
            return OperationResult.Success();
        }

		public List<PostDto> GetLatestposts()
		{
			return _context.Posts.OrderByDescending(d=>d.CreationDate)
			.Include(p => p.User)
			.Include(d => d.Category)
			.Take(5).Select(post => PostMapper.MapToDto(post)).ToList();
		}

		public List<PostDto> GetPopularPosts()
		{
			return _context.Posts.OrderByDescending(d => d.Visit)
			.Include(d => d.Category)
			.Take(5).Select(post => PostMapper.MapToDto(post)).ToList();
		}

		public PostDto GetPostById(int postId)
        {
            var post = _context.Posts
                .Include(d => d.Category)
                .Include(d => d.SubCategory)
                .FirstOrDefault(c => c.Id ==postId);
            return PostMapper.MapToDto(post);
        }

        public PostDto GetPostBySlug(string slug)
        {
            var post = _context.Posts
               .Include(d => d.Category)
               .Include(d => d.SubCategory)
               .Include(c=>c.User)
               .FirstOrDefault(c => c.Slug==slug);
            if (post == null) return null;

            return PostMapper.MapToDto(post);
        }

        public PostFilterDto GetPostFilterById(PostFilterParam filterParam)
		{
			var result=_context.Posts
                .Include(d => d.Category)
                .Include(d => d.SubCategory)
				.Include(c => c.User)
				.OrderByDescending(d=> d.CreationDate).AsQueryable();
            if(!string.IsNullOrWhiteSpace(filterParam.CategorySlug))
                result=result.Where(r=>r.Category.Slug==filterParam.CategorySlug);

            if (!string.IsNullOrWhiteSpace(filterParam.Title))
                result = result.Where(r => r.Title.Contains(filterParam.Title));

            var skip = (filterParam.PageId - 1) * filterParam.Take;
            var pagecount=result.Count()/filterParam.Take;

            return new PostFilterDto
            {
                Posts = result.Skip(skip).Take(filterParam.Take).Select(Post => PostMapper.MapToDto(Post)).ToList(),
                FilterParam = filterParam,
                PageCount = pagecount,
            };
		}

		public List<PostDto> GetRelatedPosts(int groupId)
		{
			return _context.Posts.Where(r=>r.CategoryId==groupId||r.SubCategoryId==groupId).OrderByDescending(d=>d.CreationDate)
				.Include(d => d.Category)
				.Take(3).Select(post=>PostMapper.MapToDto(post)).ToList();
		}

		public void IncreaseVisit(int postId)
		{
			var post = _context.Posts
				.First(p => p.Id == postId);
			post.Visit += 1;
			_context.SaveChanges();
		}

		public bool IsSlugExist(string slug)
        {
            return _context.Posts.Any(c => c.Slug == slug.ToSlug());
        }
    }
}
