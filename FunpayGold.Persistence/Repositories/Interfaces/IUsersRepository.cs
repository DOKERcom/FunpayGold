using FunpayGold.Persistence.Entities;
using Microsoft.AspNetCore.Identity;

namespace FunpayGold.Persistence.Repositories.Interfaces;

public interface IUsersRepository
{
    public Task<UserEntity> GetUserById(string id);

    public Task<UserEntity> GetUserByUserName(string userName);

    public Task<List<UserEntity>> GetAllUsers();

    public Task<IdentityResult> UpdateUser(UserEntity user);

    public Task<IdentityResult> CreateUser(UserEntity user, string password);

    public Task<IdentityResult> DeleteUser(UserEntity user);
}