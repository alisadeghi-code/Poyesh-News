using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.CoreLayer.DTOs.Comment;
using Weblog.CoreLayer.Utilities;

namespace Weblog.CoreLayer.Services.Comment
{
	public interface ICommentService
	{
		OperationResult CreateComment(CreateCommentDto command);
		List<CommentDto> GetPostComments(int postId);
	}
}
