using AutoMapper;
using OTS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using OTS.Data.Models;
using OTS.Data.Entities;

namespace OTS.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Test
            CreateMap<TestCreateModel, Test>();

            #endregion

            #region User
            CreateMap<User, UserModel>()
                .ForMember(destination => destination.UserId, 
                    option => option.MapFrom(source => source.Id))
                .ForMember(destination => destination.Email, 
                    option => option.MapFrom(source => source.Email))
                .ForMember(destination => destination.UserName, 
                    option => option.MapFrom(source => source.UserName))
                .ForMember(destination => destination.Password, 
                    option => option.MapFrom(source => source.PasswordHash))
                .ForMember(destination => destination.AvatarSeed, 
                    option => option.MapFrom(source => source.AvatarSeed));

            #endregion
        }
    }
}
