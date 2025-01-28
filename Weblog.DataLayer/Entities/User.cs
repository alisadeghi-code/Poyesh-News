using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weblog.DataLayer.Entities
{
    public class User : BaseEntity
    {

        [Required]
        public string UserName { get; set; }

        public string FullName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }


        public string Interest { get; set; }
        public string Frequency { get; set; }
        public string Sources { get; set; }
        public string NewsType { get; set; }
        public string Discussion { get; set; }

        #region Relations
        public ICollection<Post> Posts { get; set; }
        public ICollection<PostComment> PostComments { get; set; }
        #endregion
    }

    public enum UserRole
    {
        Admin,
        User,
        Writer,
    }
}
