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
                .ForMember(destination => destination.UserName,
                    option => option.MapFrom(source => source.UserName))
                .ForMember(destination => destination.Password,
                    option => option.MapFrom(source => source.PasswordHash));
            CreateMap<UserModel, User>()
                .ForMember(destination => destination.Id,
                    option => option.MapFrom(source => source.UserId))
                .ForMember(destination => destination.PasswordHash,
                    option => option.MapFrom(source => source.Password));

            CreateMap<SignUpModel, User>()
                .ForMember(destination => destination.UserName,
                    option => option.MapFrom(source => source.Username))
                .ForMember(destination => destination.PasswordHash,
                    option => option.MapFrom(source => source.Password));

            #endregion

            #region Role
            CreateMap<CreateRoleModel, Role>();
            CreateMap<Role, RoleModel>()
                .ForMember(destination => destination.RoleId,
                    option => option.MapFrom(source => source.Id));
            #endregion

            #region Submit
            CreateMap<Submit, SubmitModel>();
            CreateMap<SubmitModel, Submit>();
            #endregion

            #region Blacklist
            CreateMap<BlacklistModel, Blacklist>();
            CreateMap<Blacklist, BlacklistModel>();
            #endregion
        }
    }
}
