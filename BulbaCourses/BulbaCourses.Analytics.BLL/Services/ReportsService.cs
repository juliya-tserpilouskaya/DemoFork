using AutoMapper;
using BulbaCourses.Analytics.BLL.Ensure;
using BulbaCourses.Analytics.BLL.Interface;
using BulbaCourses.Analytics.DAL.Interface;
using BulbaCourses.Analytics.DAL.Models;
using BulbaCourses.Analytics.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.BLL.Services
{
    /// <summary>
    /// Provides a mechanism for working Report.
    /// </summary>
    public class ReportsService : IReportsService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ReportDb> _repository;

        /// <summary>
        /// Creates a new report service.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        public ReportsService(IMapper mapper, IRepository<ReportDb> repository)
        {
            _mapper = mapper;
            _repository = repository;
            // if need adding data to uncomment Seed.SeedDatabase(repository);
        }        

        /// <summary>
        /// Updates a report.
        /// </summary>
        /// <param name="reportDto"></param>
        /// <returns></returns>
        public async Task<ReportDto> UpdateAsync(ReportDto reportDto)
        {
            reportDto.Name = reportDto.Name.SpaceFix();
            reportDto.Description = reportDto.Description.SpaceFix();
            reportDto.Modified = DateTime.Now;
            reportDto.Modifier = "Имя обновившего клиента";

            var reportDb = _mapper.Map<ReportDb>(reportDto);
            await _repository.UpdateAsync(reportDb).ConfigureAwait(false);

            return reportDto;
        }

        /// <summary>
        /// Creates a report.
        /// </summary>
        /// <param name="reportDto"></param>
        /// <returns></returns>
        public async Task<ReportDto> CreateAsync(ReportDto reportDto)
        {
            reportDto.Id = Guid.NewGuid().ToString();
            reportDto.Created = DateTime.Now;
            reportDto.Modified = DateTime.Now;
            reportDto.Creator = "Виталий";
            reportDto.Modifier = "Виталий";
            reportDto.Name = reportDto.Name.SpaceFix();
            reportDto.Description = reportDto.Description.SpaceFix();

            var reportDb = _mapper.Map<ReportDb>(reportDto);
            await _repository.CreateAsync(reportDb).ConfigureAwait(false);

            return reportDto;
        }

        /// <summary>
        /// Shows a report details by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ReportDto> GetByIdAsync(string id)
        {
            var reportDb = await _repository.ReadAsync(_ => _.Id == id).ConfigureAwait(false);
            var reportDto = _mapper.Map<ReportDto>(reportDb);

            return reportDto;
        }

        /// <summary>
        /// Shows a reports details by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="stringOption"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ReportDto>> GetAllByNameAsync(string name, Search.StringOption stringOption)
        {
            var option = GetSearchNameOptions(name, stringOption);
            var reportDbs = await _repository.ReadAllAsync(option, _ => _.Name).ConfigureAwait(false);
            var reportDtos = _mapper.Map<List<ReportDto>>(reportDbs);

            return reportDtos;
        }

        /// <summary>
        /// Gets all reports.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ReportDto>> GetAllAsync()
        {
            var reportDbs = await _repository.ReadAllAsync(_ => _.Name).ConfigureAwait(false);
            var reportDtos = _mapper.Map<List<ReportDto>>(reportDbs);

            return reportDtos;
        }

        /// <summary>
        /// Removes a report by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(string id)
        {
            return await _repository.DeleteAsync(_ => _.Dashboards, _ => _.Id == id).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks if a report exists by Name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<bool> ExistsNameAsync(string name)
        {
            return await _repository.ExistsAsync(_ => _.Name == name).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks if a report exists by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> ExistsIdAsync(string id)
        {
            return await _repository.ExistsAsync(_ => _.Id == id).ConfigureAwait(false);
        }

        private Expression<Func<ReportDb, bool>> GetSearchNameOptions(string name, Search.StringOption stringOption)
        {
            Expression<Func<ReportDb, bool>> expressionWhere;
            switch (stringOption)
            {
                case Search.StringOption.Equals:
                    expressionWhere = _ => _.Name.Equals(name);
                    break;
                case Search.StringOption.StartsWith:
                    expressionWhere = _ => _.Name.StartsWith(name);
                    break;
                case Search.StringOption.EndsWith:
                    expressionWhere = _ => _.Name.EndsWith(name);
                    break;
                case Search.StringOption.Contains:
                    expressionWhere = _ => _.Name.Contains(name);
                    break;
                default:
                    expressionWhere = _ => _.Name.StartsWith(name);
                    break;
            }
            return expressionWhere;
        }
    }
}
