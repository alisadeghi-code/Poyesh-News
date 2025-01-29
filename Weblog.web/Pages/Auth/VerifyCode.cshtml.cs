using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Weblog.CoreLayer.Services.Users;
using Weblog.CoreLayer.Utilities;
using Weblog.DataLayer.Entities;

namespace Weblog.web.Pages.Auth
{
    [BindProperties]
    public class VerifyCodeModel : PageModel
    {
        private readonly IUserService _userService;
       

        public VerifyCodeModel(IUserService userService)
        {
            _userService = userService;
        }
        
        public string Code { get; set; }

        public void OnGet()
        {

            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var expectedCode = TempData.Peek("VerificationCode") as string;
            var expirationTime = TempData.Peek("VerificationCodeExpiration") as DateTime?;
            var email = TempData.Peek("Email") as string;
            var username = TempData.Peek("Username") as string;
            var password = TempData.Peek("Password") as string;
            var fullname = TempData.Peek("Fullname") as string;

            
            if (string.IsNullOrEmpty(expectedCode) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(password) || !expirationTime.HasValue || expirationTime.Value < DateTime.UtcNow)
            {
                ModelState.AddModelError( "Code","دوباره تلاش کنید");
                return Page();
            }

            
            if (Code != expectedCode)
            {
                ModelState.AddModelError("Code", "کد معتبر را وارد کنید");
                return Page();
            }




            var user = new User
            {
                Email = email,
                UserName = username,
                Password = password.EncodeToMd5(),
                FullName= fullname,
                IsDelete = false,
                Role = UserRole.User,
                CreationDate = DateTime.Now,

            };

            var userId = await _userService.SignUpUserAsync(user);

            TempData["UserId"] = userId;

            TempData.Keep("UserId");




            TempData.Remove("VerificationCode");
            TempData.Remove("VerificationCodeExpiration");
            TempData.Remove("Email");
            TempData.Remove("Username");
            TempData.Remove("Password");
            TempData.Remove("Fullname");

            return RedirectToPage("Questions");
        }
    }


}

