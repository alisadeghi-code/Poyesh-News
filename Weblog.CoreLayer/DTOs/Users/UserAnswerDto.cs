using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weblog.CoreLayer.DTOs.Users
{
    public class UserAnswerDto
    {
        [Required(ErrorMessage = "یکی از گزینه هارا انتخاب کنید")]
        public string Interest { get; set; }
        [Required(ErrorMessage = "یکی از گزینه هارا انتخاب کنید")]
        public string Frequency { get; set; }
        [Required(ErrorMessage = "یکی از گزینه هارا انتخاب کنید")]
        public string Sources { get; set; }
        [Required(ErrorMessage = "یکی از گزینه هارا انتخاب کنید")]
        public string NewsType { get; set; }
        [Required(ErrorMessage = "یکی از گزینه هارا انتخاب کنید")]
        public string Discussion { get; set; }
    }
}
