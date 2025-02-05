using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.CoreLayer.DTOs.Comment;
using Weblog.CoreLayer.Utilities;
using Weblog.DataLayer.Context;
using Weblog.DataLayer.Entities;

namespace Weblog.CoreLayer.Services.Comment
{
	public class CommentService : ICommentService
	{
		private readonly BlogContext _blogContext;

		public CommentService(BlogContext blogContext)
		{
			_blogContext = blogContext;
		}

		public OperationResult CreateComment(CreateCommentDto command)
		{
			var comment=new PostComment() 
			{
				UserId = command.UserId,
				PostId = command.PostId,
				Text = command.Text,
			};
			_blogContext.Add(comment);
			_blogContext.SaveChanges();
			return OperationResult.Success();
		}

		public List<CommentDto> GetPostComments(int postId)
		{
			return _blogContext.PostComments
                .Include(c => c.User)
				.Where(c=>c.PostId == postId)
				.Select(comment=>new CommentDto() 
				{
					PostId=comment.PostId,
					Text=comment.Text,
					UserFullName=comment.User.FullName,
					CommentId=comment.PostId
				}).ToList();
		}
	}
}
