using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Weblog.CoreLayer.Services.Users;
using Weblog.CoreLayer.DTOs.Users;
using Weblog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Security.Claims;
using Weblog.DataLayer.Entities;

namespace Weblog.web.Pages.Auth
{
    [ValidateAntiForgeryToken]
    [BindProperties]
    public class SignInModel : PageModel
    {
        private readonly IUserService _userService;

        public SignInModel(IUserService userService)
        {
            _userService = userService;
        }


        [Required(ErrorMessage ="نام کاربری را وارد کنید")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="رمز عبور را وارد کنید ")]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            if(ModelState.IsValid==false) 
            {
                return Page();
            }

            var user = _userService.SigninUser(new UserSignInDto()
            {
                Password = Password,
                UserName = UserName
            });

            if (user == null)
            {
                ModelState.AddModelError("UserName", "کاربری با مشخصات وارد شده یافت نشد");
                return Page();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim("Test","Test"),
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.FullName),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = true
            };
            HttpContext.SignInAsync(claimPrincipal, properties);
            return RedirectToPage("../Index");

        }
    }
}
