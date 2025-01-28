using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using Weblog.CoreLayer.Services.Email;
using Weblog.CoreLayer.Services.Users;

namespace Weblog.web.Pages.Auth
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class ForgotModel : PageModel
    {
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;

        public ForgotModel(IEmailService emailService, IUserService userService)
        {
            _emailService = emailService;
            _userService = userService;
        }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "ایمیل را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل معتبر وارد کنید")]
        public string Email { get; set; }
        public void OnGet()
        {
            
            var referer = Request.Headers["Referer"].ToString();
            if (string.IsNullOrEmpty(referer) || !referer.Contains("SignIn"))
            {
                
                Response.Redirect("../Error");
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            var user = _userService.GetUserByEmail(Email);
            if (user == null)
            {
                ModelState.AddModelError("Email", " این ایمیل قبلا ثبت نام نشده است");
                return Page();
            }

            var verificationCode = new Random().Next(100000, 999999).ToString();


            TempData["VerificationCode"] = verificationCode;
            TempData["VerificationCodeExpiration"] = DateTime.UtcNow.AddMinutes(5);

            TempData.Keep("VerificationCode");
            TempData.Keep("VerificationCodeExpiration");
            _emailService.SendEmailAsync(
                Email, "کد بازیابی رمز عبور", $"کد شما: {verificationCode}");

            return RedirectToPage("ResetPassword"); 
        }
    }
}
