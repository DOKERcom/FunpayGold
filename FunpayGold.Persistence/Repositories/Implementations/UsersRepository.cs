using FunpayGold.Persistence.Entities;
using FunpayGold.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FunpayGold.Persistence.Repositories.Implementations;

public class UsersRepository : IUsersRepository
{
    private readonly UserManager<UserEntity> _userManager;

    public UsersRepository(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UserEntity> GetUserById(string id)
    {
        return await _userManager.FindByIdAsync(id);
    }

    public async Task<UserEntity> GetUserByUserName(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        return user;
    }

    public async Task<bool> IsUserExists(string userName)
    {
        return GetUserByUserName(userName) != null ? true : false;
    }

    public async Task<List<UserEntity>> GetAllUsers()
    {
        return await _userManager.Users.Include(b=>b.Bots).ToListAsync();
    }

    public async Task<IdentityResult> UpdateUser(UserEntity user)
    {
        var result = await _userManager.UpdateAsync(user);

        return result;
    }

    public async Task<IdentityResult> CreateUser(UserEntity user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<IdentityResult> DeleteUser(UserEntity user)
    {
        return await _userManager.DeleteAsync(user);
    }
}