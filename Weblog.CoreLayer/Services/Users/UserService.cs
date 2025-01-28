using Weblog.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Weblog.CoreLayer.DTOs.Users;
using Weblog.DataLayer.Context;
using Weblog.DataLayer.Entities;
using System.Net.Http;

namespace Weblog.CoreLayer.Services.Users
{
    public class UserService : IUserService
    {
        private readonly BlogContext _context;

        public UserService(BlogContext context)
        {
            _context = context;
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public bool IsEmailTaken(string email)
        {
            return _context.Users.Any(u => u.Email ==email );
        }

        public bool IsUsernameTaken(string username)
        {
            
            return _context.Users.Any(u => u.UserName == username);
        }

        public UserDto SigninUser(UserSignInDto signInDto)
        {
            var passwordHashed = signInDto.Password.EncodeToMd5();
            var user = _context.Users
                .FirstOrDefault(u => u.UserName == signInDto.UserName && u.Password == passwordHashed);

            if (user == null)
                return null;

            var userDto = new UserDto()
            {
                FullName = user.FullName,
                Password = user.Password,
                Role = user.Role,
                UserName = user.UserName,
                RegisterDate = user.CreationDate,
                UserId = user.Id,
                Email= user.Email,
            };
            return userDto;
        }

          

        public async Task<int> SignUpUserAsync(User user)
        {

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<bool> UpdateUserAnswersAsync(int userId, UserAnswerDto dto)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return false;
            }

           
            user.Interest = dto.Interest;
            user.Frequency = dto.Frequency;
            user.Sources = dto.Sources;
            user.NewsType = dto.NewsType;
            user.Discussion = dto.Discussion;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
