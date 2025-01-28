using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Weblog.CoreLayer.DTOs.Users;
using Weblog.CoreLayer.Services.Users;
using Weblog.DataLayer.Entities;
using Weblog.DataLayer.Migrations;

namespace Weblog.web.Pages.Auth
{
   
    [ValidateAntiForgeryToken]
    public class QuestionsModel : PageModel
    {
        private readonly IUserService _userService;

        public QuestionsModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public UserAnswerDto UserAnswers { get; set; }

        public IActionResult OnGet()
        {
            var userId = TempData.Peek("UserId") as int?;

            if (userId == null)
            {
                return RedirectToPage("../Error");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userId = TempData.Peek("UserId") as int?;
            if (userId == null)
            {
                return RedirectToPage("../Error");
            }

            
            var result = await _userService.UpdateUserAnswersAsync(userId.Value, UserAnswers);

            if (!result)
            {
                return Page();
            }

            return RedirectToPage("../Index");
        }


    }
}
