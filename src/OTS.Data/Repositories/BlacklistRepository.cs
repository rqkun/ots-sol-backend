using AutoMapper;
using OTS.Common.ErrorHandle;
using OTS.Data.Entities;
using OTS.Data.Interfaces;
using OTS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data.Repositories
{
    public class BlacklistRepository : Repository<Blacklist>, IBlacklistRepository
    {
        private readonly IMapper _mapper;
        protected readonly OTsystemDB _dbContext;
        public BlacklistRepository(OTsystemDB dbContext, /*UnitOfWork uow,*/ IMapper mapper) : base(dbContext)
        { 
            this._mapper = mapper;
            this._dbContext = dbContext;
        }
        public async Task<bool> Create(CreateBlackListModel model)
        {
            var entity = _mapper.Map<Blacklist>(model);
            await this.Add(entity);
            return await Task.FromResult(true);

        }

        public async Task<bool> Delete(Guid id)
        {

            this.Remove(id);
            return await Task.FromResult(true);
        }

        public async Task<BlacklistModel> Get(Guid id)
        {
            var entity = this.GetById(id)?? throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.BlacklistNotFound);
            BlacklistModel model = _mapper.Map<BlacklistModel>(entity);
            return await Task.FromResult(model);
        }

        public async Task<ICollection<BlacklistModel>> GetAll(FilterModel filter)
        {
            var list = this.GetAll();
            ICollection<BlacklistModel> modelList = [];
            foreach (var item in list)
            {
                BlacklistModel submitModel = _mapper.Map<BlacklistModel>(item);
                modelList.Append(submitModel);
            }
            return await Task.FromResult(modelList);
        }

        public async Task<bool> Update(BlacklistUpdateModel model)
        {
            var entity = this.GetById(model.BlacklistId) ?? throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.BlacklistNotFound);
            await this.Update(entity);
            return await Task.FromResult(true);
        }
    }
}
