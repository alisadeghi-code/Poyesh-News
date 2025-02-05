using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.CoreLayer.DTOs.Comment;

namespace Weblog.CoreLayer.Services.Comment
{
	public interface ICommentService
	{
		void CreateComment(CreateCommentDto command);
		List<CommentDto> GetPostComments(int postId);
	}
}
