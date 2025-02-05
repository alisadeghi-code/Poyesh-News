using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weblog.CoreLayer.DTOs.Comment
{
	public class CreateCommentDto
	{
		public int PostId { get; set; }

		public int UserId { get; set; }

		public string Text { get; set; }
	}

	public class CommentDto : CreateCommentDto 
	{
		public string UserFullName { get; set; }
        public int CommentId { get; set; }
    }
}
