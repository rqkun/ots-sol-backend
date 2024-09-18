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
                    option => option.MapFrom(source => source.EndDate))
                .ForMember(destination => destination.TestCode,
                    option => option.MapFrom(source => source.TestCode))
                .ForMember(destination => destination.QuestionForTestViewModels,
                    option => option.MapFrom(source => source.QuestionForTests));
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

            CreateMap<QuestionForTestViewModel, QuestionForTest>();

            CreateMap<QuestionForTest, QuestionForTestViewModel>()
                .ForMember(destination => destination.QuestionForTestId,
                    option => option.MapFrom(source => source.QuestionForTestId))
                .ForMember(destination => destination.TestId,
                    option => option.MapFrom(source => source.TestId))
                .ForMember(destination => destination.QuestionId,
                    option => option.MapFrom(source => source.QuestionId))
                .ForMember(destination => destination.QuestionViewModel,
                    option => option.MapFrom(source => source.Question));
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
                    option => option.MapFrom(source => source.Detail))
                .ForMember(destination => destination.AnswerViewModels,
                    option => option.MapFrom(source => source.Answers));
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
