using FunpayGold.Application.Commands.HomeController;
using FunpayGold.Application.Models;
using FunpayGold.Application.Services.Interfaces;
using FunpayGold.Common.ResultModels;
using MediatR;

namespace FunpayGold.Application.CommandHandlers.HomeController
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ResultActionModel>
    {

        private readonly IUsersService _usersService;

        public RegisterCommandHandler(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public async Task<ResultActionModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            var model = new UserModel();

            model.Username = request.RegisterModel.Username;

            model.Email = request.RegisterModel.Email;

            if(await _usersService.IsUserExists(request.RegisterModel.Username))
                return new ResultActionModel(400, "Пользователь с таким ником уже существует!");

            var result = await _usersService.CreateUser(model, request.RegisterModel.Password);

            if(result.Succeeded)
                return new ResultActionModel();
            else
                return new ResultActionModel(500, "Произошла ошибка при регистрации, обратитесь к администратору!");
        }

    }
}
