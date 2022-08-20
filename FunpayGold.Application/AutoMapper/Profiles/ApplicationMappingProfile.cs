﻿using AutoMapper;
using FunpayGold.Application.Models;
using FunpayGold.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.AutoMapper.Profiles
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<TaskEntity, TaskModel>().ReverseMap();

            CreateMap<UserEntity, UserModel>().ReverseMap();
        }

    }
}