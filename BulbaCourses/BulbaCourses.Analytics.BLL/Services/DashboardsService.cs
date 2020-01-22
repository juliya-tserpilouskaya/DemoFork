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
    /// Provides a mechanism for working dashboard.
    /// </summary>
    public class DashboardsService : IDashboardsService
    {
        private readonly IMapper _mapper;
        private readonly IDashboardsRepository _repository;

        /// <summary>
        /// Creates a new dashboard service.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        public DashboardsService(IMapper mapper, IDashboardsRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
            // if need adding data to uncomment Seed.SeedDatabase(repository);
        }

        /// <summary>
        /// Updates a dashboard.
        /// </summary>
        /// <param name="dashboardDto"></param>
        /// <returns></returns>
        public async Task<DashboardDto> UpdateAsync(DashboardDto dashboardDto)
        {
            dashboardDto.Name = dashboardDto.Name.SpaceFix();
            dashboardDto.Modified = DateTime.Now;
            dashboardDto.Modifier = "Имя обновившего клиента";

            var dashboardDb = _mapper.Map<DashboardDb>(dashboardDto);
            await _repository.UpdateAsync(dashboardDb).ConfigureAwait(false);

            return dashboardDto;
        }

        /// <summary>
        /// Creates a dashboard.
        /// </summary>
        /// <param name="dashboardDto"></param>
        /// <returns></returns>
        public async Task<DashboardDto> CreateAsync(DashboardDto dashboardDto)
        {
            dashboardDto.Id = Guid.NewGuid().ToString();
            dashboardDto.Created = DateTime.Now;
            dashboardDto.Modified = DateTime.Now;
            dashboardDto.Creator = "Виталий";
            dashboardDto.Modifier = "Виталий";
            dashboardDto.Name = dashboardDto.Name.SpaceFix();

            var dashboardDb = _mapper.Map<DashboardDb>(dashboardDto);
            await _repository.CreateAsync(dashboardDb).ConfigureAwait(false);

            return dashboardDto;
        }

        /// <summary>
        /// Shows a dashboard details by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DashboardDto> GetByIdAsync(string id)
        {
            var dashboardDb = await _repository.ReadAsync(_ => _.Id == id).ConfigureAwait(false);
            var dashboardDto = _mapper.Map<DashboardDto>(dashboardDb);

            return dashboardDto;
        }

        /// <summary>
        /// Shows a Dashboards details by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="stringOption"></param>
        /// <returns></returns>
        public async Task<IEnumerable<DashboardDto>> GetAllByNameAsync(string name, Search.StringOption stringOption)
        {
            var option = GetSearchNameOptions(name, stringOption);
            var dashboardDbs = await _repository.ReadAllAsync(option, _ => _.Name).ConfigureAwait(false);
            var dashboardDtos = _mapper.Map<List<DashboardDto>>(dashboardDbs);

            return dashboardDtos;
        }

        /// <summary>
        /// Gets all Dashboards.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DashboardDto>> GetAllAsync()
        {
            var dashboardDbs = await _repository.ReadAllAsync(_ => _.Name).ConfigureAwait(false);
            var dashboardDtos = _mapper.Map<List<DashboardDto>>(dashboardDbs);

            return dashboardDtos;
        }

        /// <summary>
        /// Removes a dashboard by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(string id)
        {
            return await _repository.DeleteAsync(_ => _.Id == id).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks if a dashboard exists by Name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<bool> ExistsNameAsync(string name)
        {
            return await _repository.ExistsAsync(_ => _.Name == name).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks if a dashboard exists by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> ExistsIdAsync(string id)
        {
            return await _repository.ExistsAsync(_ => _.Id == id).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks if a report exists by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> ExistsReportIdAsync(string id)
        {
            return await _repository.ExistsReportAsync(_ => _.Id == id).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks if a chart exists by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> ExistsChartIdAsync(int id)
        {
            return await _repository.ExistsChartAsync(_ => _.Id == id).ConfigureAwait(false);
        }

        private Expression<Func<DashboardDb, bool>> GetSearchNameOptions(string name, Search.StringOption stringOption)
        {
            Expression<Func<DashboardDb, bool>> expressionWhere;
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
