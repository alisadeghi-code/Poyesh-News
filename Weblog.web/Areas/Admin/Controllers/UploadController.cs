using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weblog.CoreLayer.Services.FileManager;
using Weblog.CoreLayer.Utilities;

namespace Weblog.web.Areas.Admin.Controllers
{
    
    public class UploadController : Controller
    {
        private readonly IFileManager _filemanager;

        public UploadController(IFileManager filemanager)
        {
            _filemanager = filemanager;
        }
        [Route("Upload/Article")]
        public IActionResult Article(IFormFile upload)
        {
            

            if (upload == null)
                BadRequest();

            var imageName = _filemanager.SaveFile(upload, Directories.PostImageContent);

            return Json (new { Uploaded = true,url= Directories.GetPostImageContent(imageName) });
        }
    }
}
