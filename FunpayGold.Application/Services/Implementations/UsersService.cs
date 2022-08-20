using AutoMapper;
using FunpayGold.Application.Models;
using FunpayGold.Application.Services.Interfaces;
using FunpayGold.Persistence.Entities;
using FunpayGold.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FunpayGold.Application.Services.Implementations;

public class UsersService : IUsersService
{

    private readonly IUsersRepository _usersRepository;

    private readonly IMapper _mapper;

    public UsersService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;

        _mapper = mapper;
    }

    public async Task<UserModel> GetUserById(string id)
    {
        return _mapper.Map<UserModel>(await _usersRepository.GetUserById(id));
    }

    public async Task<UserModel> GetUserByLogin(string userName)
    {
        return _mapper.Map<UserModel>(await _usersRepository.GetUserByUserName(userName));
    }

    public async Task<bool> IsUserExists(string userName)
    {
        return await _usersRepository.IsUserExists(userName);
    }

    public async Task<List<UserModel>> GetAllUsers()
    {
        return _mapper.Map<List<UserModel>>(await _usersRepository.GetAllUsers());
    }

    public async Task<IdentityResult> UpdateUser(UserModel user)
    {
        var entity = _mapper.Map<UserEntity>(user);

        return await _usersRepository.UpdateUser(entity);
    }

    public async Task<IdentityResult> CreateUser(UserModel user, string password)
    {
        var entity = _mapper.Map<UserEntity>(user);

        return await _usersRepository.CreateUser(entity, password);
    }

    public async Task<IdentityResult> DeleteUser(UserModel user)
    {
        var entity = _mapper.Map<UserEntity>(user);

        return await _usersRepository.DeleteUser(entity);
    }

}