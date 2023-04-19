using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Dto.Auth;
using UAS.Domain.Entities;

namespace UAS.Persistence.Extensions
{
    public static class SignInManagerExtensions
    {
        public static async Task<AppUser> LoginAsync(this SignInManager<AppUser> signInManager, LoginUser loginUser)
        {
            var user = await signInManager.UserManager.FindByNameAsync(loginUser.UserNameOrEmail);
            if (user == null) user = await signInManager.UserManager.FindByEmailAsync(loginUser.UserNameOrEmail);

            if (user == null) return null;

            var result = await signInManager.CheckPasswordSignInAsync(user, loginUser.Password, false);
            if (!result.Succeeded) return null;

            return user;
        }
    }
}
