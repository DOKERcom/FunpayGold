using FunpayGold.Application.Commands.HomeController;
using FunpayGold.Application.Services.Interfaces;
using FunpayGold.Common.ResultModels;
using FunpayGold.Persistence.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FunpayGold.Application.CommandHandlers.HomeController
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, ResultActionModel>
    {

        private readonly IUsersService _usersService;

        private readonly SignInManager<UserEntity> _signInManager;

        public SignInCommandHandler(IUsersService usersService, SignInManager<UserEntity> signInManager)
        {
            _usersService = usersService;

            _signInManager = signInManager;
        }

        public async Task<ResultActionModel> Handle(SignInCommand request, CancellationToken cancellationToken)
        {

            if(await _usersService.IsUserExists(request.SignInModel.Username) == false)
                return new ResultActionModel(400, "Пользователя с таким ником не существует!");

            var result =
            await _signInManager.PasswordSignInAsync(
                request.SignInModel.Username,
                request.SignInModel.Password,
                request.SignInModel.RememberMe,
                false);

            if (result.Succeeded)
                return new ResultActionModel();
            else
                return new ResultActionModel(400, "Авторизация не удалась, проверьте правильность данных!");
        }

    }
}
