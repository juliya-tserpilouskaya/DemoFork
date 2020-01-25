using AutoMapper;
using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Threading.Tasks;
using System.Linq;

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

        public async Task<Result> AddAsync(ContentLogic content, UserLogic user)
        {
            try
            {
                var audio = content.Audio;
                if (user.UploadedCourses.Any(c => c.Audios.Contains(audio)) || user.IsAdmin)
                {
                    content.Audio = audio;
                    content.Id = audio.Content;
                    var contentDb = mapper.Map<ContentLogic, ContentDb>(content);
                    await dbmanager.AddAsync(contentDb);
                    return Result.Ok(); 
                }
                else
                {
                    return Result.Fail("Unauthorized");
                }
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }

        }

        public async Task<Result<ContentLogic>> GetByIdAsync(string id, UserLogic user)
        {
            try
            {
                if (user.UploadedCourses.Any(c => c.Audios.Any(a => a.Id == id)) || user.BoughtCourses.Any(c => c.Audios.Any(a => a.Id == id)) || user.IsAdmin)
                {
                    var content = await dbmanager.GetByIdAsync(id);
                    var ContentLogic = mapper.Map<ContentDb, ContentLogic>(content);
                    return Result<ContentLogic>.Ok(ContentLogic); 
                }
                else
                {
                    return Result<ContentLogic>.Fail("Unauthorized");
                }
            }
            catch (Exception)
            {
                return Result<ContentLogic>.Fail("Exception");
            }
        }

        public Result DeleteAsync(ContentLogic content, UserLogic user)
        {
            try
            {
                if (user.UploadedCourses.Any(c => c.Audios.Any(a => a.Content == content.Id)) || user.IsAdmin)
                {
                    var contentDb = mapper.Map<ContentLogic, ContentDb>(content);
                    dbmanager.RemoveAsync(contentDb);
                    return Result.Ok(); 
                }
                else
                {
                    return Result.Fail("Unauthorized");
                }
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public async Task<Result> UpdateAsync(ContentLogic content, UserLogic user)
        {
            try
            {
                if (user.UploadedCourses.Any(c => c.Audios.Any(a => a.Content == content.Id)) || user.IsAdmin)
                {
                    var contentDb = mapper.Map<ContentLogic, ContentDb>(content);
                    await dbmanager.UpdateAsync(contentDb);
                    return Result.Ok(); 
                }
                else
                {
                    return Result.Fail("Unauthorized");
                }
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public async Task<bool> ExistsIdAsync(string id)
        {
            return await dbmanager.ExistIdAsync(id);
        }
    }
}
