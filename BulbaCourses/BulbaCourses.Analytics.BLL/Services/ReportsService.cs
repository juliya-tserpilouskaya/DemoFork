using AutoMapper;
using BulbaCourses.Analytics.BLL.Ensure;
using BulbaCourses.Analytics.BLL.Interface;
using BulbaCourses.Analytics.BLL.Resources;
using BulbaCourses.Analytics.DAL.Context;
using BulbaCourses.Analytics.DAL.Interface;
using BulbaCourses.Analytics.DAL.Models;
using BulbaCourses.Analytics.Infrastructure.Models;
using BulbaCourses.Analytics.Models.V1;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.BLL.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ReportDb> _repository;

        public ReportsService(IMapper mapper, IRepository<ReportDb> repository)
        {
            _mapper = mapper;
            _repository = repository;
            // if need adding data to uncomment SeedDatabase(_context);
        }

        static void SeedDatabase(AnalyticsContext context)
        {

            var report = new ReportDb()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Основной отчет",
                Description = "Описание основного отчета",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Creator = "Создатель отчета",
                Modifier = "Модификатор отчета",
                Dashboards = new List<DashboardDb>() {
                    new DashboardDb()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ChartId = 1,
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                        Creator = "Создатель дашборда",
                        Modifier = "Модификатор дашборда",
                        Name = "Дашборд 1"
                    }
                }
            };
            context.Reports.Add(report);
            context.SaveChanges();
        }

        public Task<ReportDto> UpdateAsync(ReportDto reportDto)
        {
            return Task.FromResult(reportDto);
        }

        public async Task<ReportDto> CreateAsync(ReportDto reportDto)
        {
            reportDto.Id = Guid.NewGuid().ToString();
            reportDto.Created = DateTime.Now;
            reportDto.Modified = DateTime.Now;
            reportDto.Creator = "Виталий";
            reportDto.Modifier = "Виталий";
            reportDto.Name = reportDto.Name.SpaceFix();

            if (!string.IsNullOrEmpty(reportDto.Description))
            {
                reportDto.Description = reportDto.Description.SpaceFix();
            }

            var reportDb = _mapper.Map<ReportDb>(reportDto);
            await _repository.CreateAsync(reportDb).ConfigureAwait(false);

            return reportDto;
        }

        public async Task<ReportDto> GetByIdAsync(string id)
        {
            var reportDb = await _repository.ReadAsync(_ => _.Id == id).ConfigureAwait(false);
            var reportDto = _mapper.Map<ReportDto>(reportDb);

            return reportDto;
        }

        public async Task<IEnumerable<ReportDto>> GetAllByNameAsync(string name, Search.StringOption stringOption)
        {
            var option = GetSearchNameOptions(name, stringOption);
            var reportDbs = await _repository.ReadAllAsync(option, _ => _.Name).ConfigureAwait(false);
            var reportDtos = _mapper.Map<List<ReportDto>>(reportDbs);

            return reportDtos;
        }

        public async Task<IEnumerable<ReportDto>> GetAllAsync()
        {
            var reportDbs = await _repository.ReadAllAsync(_ => _.Name).ConfigureAwait(false);
            var reportDtos = _mapper.Map<List<ReportDto>>(reportDbs);

            return reportDtos;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            return await _repository.DeleteAsync(_ => _.Dashboards, _ => _.Id == id).ConfigureAwait(false);
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _repository.ExistsAsync(_ => _.Name == name).ConfigureAwait(false);
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
