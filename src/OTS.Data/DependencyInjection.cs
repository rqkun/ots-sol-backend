using Microsoft.Extensions.DependencyInjection;
using OTS.Data.Interfaces;
using OTS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection service)
        {
            service.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
            service.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<ITestRepository, TestRepository>();
            service.AddTransient<IAnswerRepository, AnswerRepository>();
            service.AddTransient<IQuestionForTestRepository, QuestionForTestRepository>();
            service.AddTransient<IQuestionRepository, QuestionRepository>();
            service.AddTransient<IRoleRepository, RoleRepository>();

            return service;
        }
    }
}
