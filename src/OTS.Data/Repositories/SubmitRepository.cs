using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using OTS.Common.ErrorHandle;
using OTS.Data.Entities;
using OTS.Data.Interfaces;
using OTS.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data.Repositories
{
    public class SubmitRepository : Repository<Submit>, ISubmitRepository
    {
        private readonly IMapper _mapper;
        protected readonly OTsystemDB _dbContext;
        public SubmitRepository(OTsystemDB dbContext, /*UnitOfWork uow,*/ IMapper mapper) : base(dbContext)
        {
            //this._uow = uow;
            this._mapper = mapper;
            this._dbContext = dbContext;
        }

        public async Task<bool> Create(SubmitCreateModel model)
        {
            var submit = _mapper.Map<Submit>(model);
            await this.Add(submit);
            return await Task.FromResult(true);
        }
        public async Task<SubmitModel> Get(Guid id)
        {
            var submit = this.GetById(id) ?? throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.SubmitNotFound);
            SubmitModel submitFound = _mapper.Map<SubmitModel>(submit);
            return await Task.FromResult(submitFound);
        }
        public async Task<IEnumerable<SubmitModel>> Get()
        { 
            var list = this.GetAll();
            IEnumerable<SubmitModel> modelList = [];
            foreach (var item in list)
            {
                SubmitModel submitModel = _mapper.Map<SubmitModel>(item);
                modelList.Append(submitModel);
            }
            return await Task.FromResult(modelList);
        }
        public async Task<bool> Delete(Guid id)
        {
            var submit = this.GetById(id) ?? throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.SubmitNotFound);
            this.Remove(submit);
            return await Task<bool>.FromResult(true);
        }
        public async Task<bool> Delete(IEnumerable<Guid> idList)
        {
            IEnumerable<Submit> entityList = [];
            foreach (var id in idList)
            {
                var submit = this.GetById(id) ?? throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.SubmitNotFound);
                entityList.Append(submit);
            }
            if (!entityList.IsNullOrEmpty()) this.Remove(entityList);
            return await Task<bool>.FromResult(true);
        }
    }
}
