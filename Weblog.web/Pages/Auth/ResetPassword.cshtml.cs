using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Weblog.CoreLayer.Services.Users;

namespace Weblog.web.Pages.Auth
{
    public class ResetPasswordModel : PageModel
    {
        private readonly IUserService _userService;

        public ResetPasswordModel(IUserService userService)
        {
            _userService = userService;
        }
        [BindProperty]
        public string Code { get; set; }

        public void OnGet()
        {

           
        }

        public IActionResult OnPost()
        {
            var expectedCode = TempData.Peek("VerificationCode") as string;
            var expirationTime = TempData.Peek("VerificationCodeExpiration") as DateTime?;

            if (string.IsNullOrEmpty(expectedCode)|| !expirationTime.HasValue || expirationTime.Value < DateTime.UtcNow)
            {
                ModelState.AddModelError("Code", "کد اشتباه است");
                return Page();
            }

            if (Code != expectedCode)
            {
                ModelState.AddModelError("Code", "کد  معتبر را وارد کنید");
                return Page();
            }
            TempData.Remove("VerificationCode");
            TempData.Remove("VerificationCodeExpiration");
            return RedirectToPage("../Index");
        }

    }
}
