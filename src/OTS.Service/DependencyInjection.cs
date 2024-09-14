using Microsoft.Extensions.DependencyInjection;
using OTS.Service.Interfaces;
using OTS.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<ITestService, TestService>();
            service.AddTransient<IAnswerService, AnswerService>();
            service.AddTransient<IQuestionService, QuestionService>();
            service.AddTransient<IRoleService, RoleService>();
            service.AddTransient<ITokenService, TokenService>();
            return service;
        }
    }
}
