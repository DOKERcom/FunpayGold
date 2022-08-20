using AutoMapper;
using FunpayGold.Application.Models;
using FunpayGold.MVC.ViewModels;

namespace FunpayGold.MVC.AutoMapper.Profiles
{
    public class MvcMappingProfile : Profile
    {

        public MvcMappingProfile()
        {
            CreateMap<SignInViewModel, SignInModel>().ReverseMap();

            CreateMap<RegisterViewModel, RegisterModel>().ReverseMap();
        }

    }
}
