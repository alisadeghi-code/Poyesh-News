using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weblog.CoreLayer.DTOs.Post
{
	public class PostFilterDto
	{
       
		public List<PostDto> Posts { get; set; }
        public PostFilterParam FilterParam { get; set; }
		public int PageCount { get; set; }


	}
	public class PostFilterParam 
	{
		public string CategorySlug { get; set; }
		public string Title { get; set; }
		public int Take { get; set; }
		public int PageId { get; set; }
		
	}
}

