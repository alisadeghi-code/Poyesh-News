using Weblog.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.DataLayer.Entities;
using Weblog.CoreLayer.DTOs.Users;

namespace Weblog.CoreLayer.Services.Users
{
    public interface IUserService
    {
        User GetUserByEmail(string email);

        UserDto SigninUser(UserSignInDto signinDto);

        bool IsUsernameTaken(string username);

        bool IsEmailTaken(string email);

        Task<int> SignUpUserAsync(User user);

        Task<bool> UpdateUserAnswersAsync(int userId, UserAnswerDto dto);

    }
}
