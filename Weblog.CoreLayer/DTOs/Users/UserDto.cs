 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weblog.DataLayer.Entities;

namespace Weblog.CoreLayer.DTOs.Users
{
    public class UserDto
    {

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Email { get; set; }

       
    }
}
