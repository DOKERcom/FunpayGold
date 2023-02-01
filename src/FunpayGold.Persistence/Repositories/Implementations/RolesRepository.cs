using FunpayGold.Persistence.Entities;
using FunpayGold.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Persistence.Repositories.Implementations
{
    public class RolesRepository : IRolesRepository
    {

        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesRepository(UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IList<string> GetAllRoles()
        {
            return _roleManager.Roles.Select(r => r.Name).ToList();
        }

        public async Task<IList<string>> GetUserRoles(UserEntity user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IdentityResult> AddUserToRole(UserEntity user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> RemoveUserFromRole(UserEntity user, string role)
        {
            return await _userManager.RemoveFromRoleAsync(user, role);
        }

        public async Task<bool> IsUserInRole(UserEntity user, string role)
        {
            return await _userManager.IsInRoleAsync(user, role);
        }

    }
}
