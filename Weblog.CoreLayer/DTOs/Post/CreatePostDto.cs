using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.DataLayer.Entities;
using Weblog.CoreLayer.DTOs.Categories;
using Microsoft.AspNetCore.Http;

namespace Weblog.CoreLayer.DTOs.Post
{

    public class CreatePostDto
    {
        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public int? SubCategoryId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Slug { get; set; }
        public IFormFile ImageFile { get; set; }



    }

    public class EditPostDto : CreatePostDto
    {
        public int PostId { get; set; }

    }

    public class PostDto : EditPostDto
    {
        public string ImageName { get; set; }
        public CategoryDto Category { get; set; }
        public DateTime CreationDate { get; set; }
        public int Visit { get; set; }
        public CategoryDto SubCategory { get; set; }
        public string UserFullName { get; set; }

    }
}

