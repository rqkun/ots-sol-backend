using AutoMapper;
using OTS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.Data.Models;
using OTS.Data.Entities;
using OTS.Data.ViewModels;

namespace OTS.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Test
            CreateMap<TestCreateModel, Test>();
            CreateMap<TestUpdateModel, Test>();
            CreateMap<TestModel, Test>();

            CreateMap<Test, TestViewModel>()
                .ForMember(destination => destination.TestId,
                    option => option.MapFrom(source => source.TestId))
                .ForMember(destination => destination.CreatorId,
                    option => option.MapFrom(source => source.CreatorId))
                .ForMember(destination => destination.CreateDate,
                    option => option.MapFrom(source => source.CreateDate))
                .ForMember(destination => destination.EndDate,
                    option => option.MapFrom(source => source.EndDate));
            #endregion


            #region Answer
            CreateMap<AnswerCreateModel, Answer>();
            CreateMap<AnswerUpdateModel, Answer>();
            CreateMap<AnswerModel, Answer>();

            CreateMap<Answer, AnswerViewModel>()
                .ForMember(destination => destination.AnswerId,
                    option => option.MapFrom(source => source.AnswerId))
                .ForMember(destination => destination.AnswerDetail,
                    option => option.MapFrom(source => source.AnswerDetail))
                .ForMember(destination => destination.IsCorrect,
                    option => option.MapFrom(source => source.IsCorrect));
            #endregion


            #region QuestionForTest
            CreateMap<QuestionForTestCreateModel, QuestionForTest>();
            CreateMap<QuestionForTestModel, QuestionForTest>();

            CreateMap<QuestionForTest, QuestionForTestViewModel>()
                .ForMember(destination => destination.QuestionForTestId,
                    option => option.MapFrom(source => source.QuestionForTestId))
                .ForMember(destination => destination.TestId,
                    option => option.MapFrom(source => source.TestId));
            #endregion


            #region Question
            CreateMap<QuestionCreateModel, Question>();
            CreateMap<QuestionUpdateModel, Question>();
            CreateMap<QuestionModel, Question>();

            CreateMap<Question,  QuestionViewModel>()
                .ForMember(destination => destination.QuestionId,
                    option => option.MapFrom(source => source.QuestionId))
                .ForMember(destination => destination.QuestionNo,
                    option => option.MapFrom(source => source.QuestionNo))
                .ForMember(destination => destination.QuestionDetail,
                    option => option.MapFrom(source => source.Detail));
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
