using FunpayGold.MVC.Initializators.Intefaces;
using FunpayGold.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.MVC.Initializators.Implementations
{
    public class AdminInitializer : IAdminInitializer
    {
        UserManager<UserEntity> _userManager;

        public AdminInitializer(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        public async Task Initialize()
        {
            string usermame = "root";
            string password = "123Root!";
            string email = "root@funpaygold.com";

            if (await _userManager.FindByNameAsync(usermame) == null)
            {
                UserEntity admin = new UserEntity { Email = email, UserName = usermame };
                IdentityResult result = await _userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }

    }
}
