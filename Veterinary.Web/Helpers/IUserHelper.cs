﻿using Microsoft.AspNetCore.Identity;
using Veterinary.Web.Data.Entities;
using System.Threading.Tasks;


namespace Veterinary.Web.Helpers
{
    interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        //el identityresult verifica si hay el usuario y no lo crea
        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

    }
}
