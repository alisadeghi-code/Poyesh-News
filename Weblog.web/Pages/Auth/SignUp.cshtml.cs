using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Weblog.CoreLayer.DTOs.Users;
using Weblog.CoreLayer.Services.Email;
using Weblog.CoreLayer.Services.Users;
using Weblog.CoreLayer.Utilities;

namespace Weblog.web.Pages.Auth
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class SignUpModel : PageModel
    {
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;

        public SignUpModel(IEmailService emailService, IUserService userService)
        {
            _emailService = emailService;
            _userService = userService;
        }

        #region Properties

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string FullName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(8, ErrorMessage = "{0} باید بیشتر یا مساوی 8 کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "تأیید رمز عبور")]
        [Compare("Password", ErrorMessage = "رمز عبور و تأیید آن مطابقت ندارند.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "ایمیل را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل معتبر وارد کنید")]
        public string Email { get; set; }

        #endregion

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           
            if (_userService.IsUsernameTaken(UserName) || _userService.IsEmailTaken(Email))
            {
                if (_userService.IsUsernameTaken(UserName) && _userService.IsEmailTaken(Email)) 
                {
                    
                    ModelState.AddModelError("UserName", "نام کاربری و ایمیل قبلا استفاده شده است");
                    return Page();
                }
                else if (_userService.IsEmailTaken(Email)) 
                {
                    ModelState.AddModelError("Email", "ایمیل قبلا ثبت نام شده است");
                    return Page();
                }

                else if(_userService.IsUsernameTaken(UserName))
                {
                    ModelState.AddModelError("UserName", "نام کاربری قبلا انتخاب شده است");
                    return Page();
                }
               
            }


            
            var verificationCode = new Random().Next(100000, 999999).ToString();


           TempData["VerificationCode"] = verificationCode;
            TempData["VerificationCodeExpiration"] = DateTime.UtcNow.AddMinutes(5);
            TempData["UserName"] = UserName;
            TempData["FullName"] = FullName;
            TempData["Password"] = Password;
            TempData["Email"] = Email;


            TempData.Keep("VerificationCode");
            TempData.Keep("UserName");
            TempData.Keep("FullName");
            TempData.Keep("Password");
            TempData.Keep("Email");

            await _emailService.SendEmailAsync(
                Email,
                "کد تأیید",
                $"کد تأیید شما: {verificationCode}"
            );

           
            return RedirectToPage("VerifyCode");
        }
    }

}
