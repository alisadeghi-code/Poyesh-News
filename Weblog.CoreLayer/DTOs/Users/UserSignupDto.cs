using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weblog.CoreLayer.DTOs.Users
{
    public class UserSignupDto
    {
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

    }
}
