﻿using AutoMapper;
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

            CreateMap<UserViewModel, UserModel>().ReverseMap();

            CreateMap<BotViewModel, BotModel>().ReverseMap();

            CreateMap<BotActivityViewModel, BotActivityModel>().ReverseMap();
        }

    }
}
