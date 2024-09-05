﻿using OTS.Data;
using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Service.Interfaces;

namespace OTS.Service.Interfaces
{
    public interface ITestService
    {
        Task<TestViewModel> GetById(Guid request);
        Task<ICollection<TestViewModel>> GetAll();
        Task<bool> Create(TestCreateModel request);
        Task<bool> Update(TestUpdateModel request);
        Task<bool> Delete(TestModel request);
    }
}
