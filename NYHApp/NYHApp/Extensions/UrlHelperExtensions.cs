using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NYHApp.Controllers;
using NYHApp.Data;
using NYHApp.Models;

namespace Microsoft.AspNetCore.Mvc
{
    public static class UrlHelperExtensions
    {
        public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ConfirmEmail),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }

        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ResetPassword),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }

        public static ApplicationUser GetUserLogin(string UserName, ApplicationDbContext _context)
        {
            if(UserName != null)
            {
                return _context.Users.Where(z => z.UserName == UserName).FirstOrDefault();
            }
            return new ApplicationUser();
        }
    }
}
