using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.CoreLayer.DTOs.Comment;

namespace Weblog.CoreLayer.Services.Comment
{
	public class CommentService : ICommentService
	{
		public void CreateComment(CreateCommentDto command)
		{
			throw new NotImplementedException();
		}

		public List<CommentDto> GetPostComments(int postId)
		{
			throw new NotImplementedException();
		}
	}
}
