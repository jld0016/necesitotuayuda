using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NYHApp.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "UserName", ResourceType = typeof(Resources.Account.Resource))]
        public string User { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Account.Resource))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(Resources.Account.Resource))]
        public bool RememberMe { get; set; }
    }
}
