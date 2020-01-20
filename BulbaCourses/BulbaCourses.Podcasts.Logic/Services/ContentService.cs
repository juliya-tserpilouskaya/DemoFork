using AutoMapper;
using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Logic.Services
{
    public class ContentService : IContentService
    {
        private readonly IMapper mapper;
        private readonly IManager<ContentDb> dbmanager;

        public ContentService(IMapper mapper, IManager<ContentDb> dbmanager)
        {
            this.mapper = mapper;
            this.dbmanager = dbmanager;
        }

        public async Task<Result> AddAsync(ContentLogic content, AudioLogic audio)
        {
            try
            {
                content.Audio = audio;
                content.Id = audio.Content;
                var contentDb = mapper.Map<ContentLogic, ContentDb>(content);
                await dbmanager.AddAsync(contentDb);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }

        }

        public async Task<Result<ContentLogic>> GetByIdAsync(string id)
        {
            try
            {
                var content = await dbmanager.GetByIdAsync(id);
                var ContentLogic = mapper.Map<ContentDb, ContentLogic>(content);
                return Result<ContentLogic>.Ok(ContentLogic);
            }
            catch (Exception)
            {
                return Result<ContentLogic>.Fail("Exception");
            }
        }

        public async Task<Result> DeleteAsync(ContentLogic content)
        {

            try
            {
                var contentDb = mapper.Map<ContentLogic, ContentDb>(content);
                await dbmanager.RemoveAsync(contentDb);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public async Task<Result> UpdateAsync(ContentLogic content)
        {
            try
            {
                var contentDb = mapper.Map<ContentLogic, ContentDb>(content);
                await dbmanager.UpdateAsync(contentDb);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await dbmanager.ExistAsync(name);
        }
    }
}
