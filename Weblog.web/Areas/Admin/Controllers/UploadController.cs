using Microsoft.AspNetCore.Mvc;

namespace Weblog.web.Areas.Admin.Controllers
{
    public class UploadController : Controller
    {
        [Area("Admin")]
        public IActionResult Article()
        {
            return View();
        }
    }
}
