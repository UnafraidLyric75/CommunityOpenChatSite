using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityOpenChatSite.Models
{
    public static class IdentityHelper
    {
        public static void SetIdentityOptions(IdentityOptions options)
        {
            // set sign in options
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;

            // set password strength
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;

            // Set lockout options
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            options.Lockout.MaxFailedAccessAttempts = 3; // defualt is 5
        }
    }
}
