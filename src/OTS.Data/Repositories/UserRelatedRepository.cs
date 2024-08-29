using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
// using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using OTS.Common;
using OTS.Common.ErrorHandle;
using OTS.Data.Entities;
using OTS.Data.Interfaces;
using OTS.Data.Models;
using OTS.Data.ViewModels;

namespace OTS.Data.Repositories
{
    public class UserRelatedRepository : Repository<User>, IUserRelatedRepository
    {
        //private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        protected readonly OTsystemDB _dbContext;
        public UserRelatedRepository(OTsystemDB dbContext, /*UnitOfWork uow,*/ IMapper mapper) : base(dbContext)
        {
            //this._uow = uow;
            this._mapper = mapper;
            this._dbContext = dbContext;
        }
        public async Task<UserModel> GetById(Guid request)
        {
            var foundUser = await Entities.FirstOrDefaultAsync(u => u.Id == request) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.UserNotFound);
            try
            {
                var user = _mapper.Map<UserModel>(foundUser);
                return await Task.FromResult<UserModel>(user); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }
    }
}
