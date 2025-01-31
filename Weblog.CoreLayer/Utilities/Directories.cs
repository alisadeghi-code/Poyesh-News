using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weblog.CoreLayer.Utilities
{
    public class Directories
    {
        public const string PostImage = "wwwroot/img/posts";
        public const string PostImageContent = "wwwroot/img/posts/content";
        public static string GetPostImage(string imageName) => $"{PostImage.Replace("wwwroot", "")}/{imageName}";
        public static string GetPostImageContent(string imageName) => $"{PostImageContent.Replace("wwwroot", "")}/{imageName}";
    }
}
