using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTracker_ProjectDLL.CustomClass
{
    public class ResetPassword
    {
        [Required(ErrorMessage = "New Password Required!")]
        [DataType(DataType.EmailAddress)]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "New password and confirm password does not match!")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string ResetCode { get; set; }
    }
}
