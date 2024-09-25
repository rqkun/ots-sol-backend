using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using OTS.Common;
using OTS.Common.ErrorHandle;
using OTS.Data.Entities;
using OTS.Data.Interfaces;
using OTS.Data.Models;
using OTS.Data.ViewModels;

namespace OTS.Data.Repositories
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        //private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        protected readonly OTsystemDB _dbContext;
        public ReportRepository(OTsystemDB dbContext, /*UnitOfWork uow,*/ IMapper mapper) : base(dbContext)
        {
            //this._uow = uow;
            this._mapper = mapper;
            this._dbContext = dbContext;
        }

        public async Task<ReportViewModel> Get(Guid request)
        {
            var foundReport = this.GetById(request) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.ReportNotFound);
            try
            {
                var report = _mapper.Map<ReportViewModel>(foundReport);
                return await Task.FromResult<ReportViewModel>(report); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<AllReportViewModel> GetAll(FilterModel filter)
        {
            filter.Page = filter.Page != 0 ? filter.Page : 1;
            filter.Limit = filter.Limit != 0 ? filter.Limit : 10;
            var foundReports = await Entities.ToListAsync() ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.ReportNotFound);
            try
            {
                var ReportList = new List<ReportViewModel>();
                foreach (var Report in foundReports)
                {
                    var obj = _mapper.Map<ReportViewModel>(Report);
                    ReportList.Add(obj);
                }
                int totalCount = ReportList.Count;
                ReportList = ReportList.Skip((filter.Page - 1) * filter.Limit).Take(filter.Limit).ToList();
                AllReportViewModel result = new AllReportViewModel()
                {
                    Total = totalCount,
                    Page = filter.Page,
                    Limit = filter.Limit,
                    ReportViewModels = ReportList
                };
                return await Task.FromResult(result); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<bool> CreateReport(ReportCreateModel request)
        {
            try
            {
                var newReport = _mapper.Map<Report>(request);
                //newReport.ReportId = Guid.NewGuid();

                await this.Add(newReport);
                return await Task.FromResult(true); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<bool> UpdateReport(ReportUpdateModel request)
        {
            var foundReport = await Entities.Where(r => r.IsDeleted == false).FirstOrDefaultAsync(r => r.ReportId == request.ReportId) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.ReportNotFound);
            try
            {
                var updateReport = _mapper.Map<Report>(request);
                updateReport.TestId = foundReport.TestId;

                await this.Update(foundReport, updateReport);
                return await Task.FromResult(true); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<bool> DeleteReport(ReportModel request)
        {
            var foundReport = await Entities.Where(r => r.IsDeleted == false).FirstOrDefaultAsync(r => r.ReportId == request.ReportId) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.ReportNotFound);
            try
            {
                var deleteReport = _mapper.Map<Report>(foundReport);
                deleteReport.TestId = foundReport.TestId;
                deleteReport.IsDeleted = true;

                await this.Update(foundReport, deleteReport);
                return await Task.FromResult(true); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }
    }
}
