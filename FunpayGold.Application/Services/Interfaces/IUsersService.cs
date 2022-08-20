using FunpayGold.Application.Models;
using Microsoft.AspNetCore.Identity;

namespace FunpayGold.Application.Services.Interfaces;

public interface IUsersService
{
    public Task<UserModel> GetUserById(string id);

    public Task<UserModel> GetUserByLogin(string userName);

    public Task<bool> IsUserExists(string userName);

    public Task<List<UserModel>> GetAllUsers();

    public Task<IdentityResult> UpdateUser(UserModel user);

    public Task<IdentityResult> CreateUser(UserModel user, string password);

    public Task<IdentityResult> DeleteUser(UserModel user);
}