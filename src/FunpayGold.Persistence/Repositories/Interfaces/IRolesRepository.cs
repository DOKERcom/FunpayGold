using FunpayGold.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Persistence.Repositories.Interfaces
{
    public interface IRolesRepository
    {

        public IList<string> GetAllRoles();

        public Task<IList<string>> GetUserRoles(UserEntity user);

        public Task<IdentityResult> AddUserToRole(UserEntity user, string role);

        public Task<IdentityResult> RemoveUserFromRole(UserEntity user, string role);

        public Task<bool> IsUserInRole(UserEntity user, string role);

    }
}
