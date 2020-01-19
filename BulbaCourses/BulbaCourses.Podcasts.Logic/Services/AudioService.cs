using AutoMapper;
using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace BulbaCourses.Podcasts.Logic.Services
{
    public class AudioService : IAudioService
    {
        private readonly IMapper mapper;
        private readonly IManager<AudioDb> dbmanager;

        public AudioService(IMapper mapper, IManager<AudioDb> dbmanager)
        {
            this.mapper = mapper;
            this.dbmanager = dbmanager;
        }

        public async Task<Result> AddAsync(AudioLogic audio, CourseLogic course)
        {
            try
            {
                audio.Course = course;
                audio.Content = Guid.NewGuid().ToString();
                audio.Id = Guid.NewGuid().ToString();
                var audioDb = mapper.Map<AudioLogic, AudioDb>(audio);
                var result = await dbmanager.AddAsync(audioDb);
                return Result.Ok();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbUpdateException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbEntityValidationException e)
            {
                return Result.Fail(e.Message);
            }
            catch (Exception)
            {
                return await Task.FromResult(Result.Fail("Exception"));
            }

        }

        public async Task<Result<AudioLogic>> GetByIdAsync(string Id)
        {
            try
            {
                var audio = await dbmanager.GetByIdAsync(Id);
                var AudioLogic = mapper.Map<AudioDb, AudioLogic>(audio);
                return Result<AudioLogic>.Ok(AudioLogic);
            }
            catch (Exception)
            {
                return Result<AudioLogic>.Fail("Exception");
            }
        }

        public async Task<Result<IEnumerable<AudioLogic>>> SearchAsync(string Name)
        {
            try
            {
                var audio = (await dbmanager.GetAllAsync()).Where(c => c.Name.Contains(Name)).ToList();
                var AudioLogic = mapper.Map<IEnumerable<AudioDb>, IEnumerable<AudioLogic>>(audio);
                return Result<IEnumerable<AudioLogic>>.Ok(AudioLogic);
            }
            catch (Exception)
            {
                return Result<IEnumerable<AudioLogic>>.Fail("Exception");
            }
        }

        public async Task<Result<IEnumerable<AudioLogic>>> GetAllAsync()
        {
            try
            {
                var audios = await dbmanager.GetAllAsync();
                var result = mapper.Map<IEnumerable<AudioDb>, IEnumerable<AudioLogic>>(audios);
                return Result<IEnumerable<AudioLogic>>.Ok(result);
            }
            catch (Exception)
            {
                return Result<IEnumerable<AudioLogic>>.Fail("Exception");
            }
        }

        public async Task<Result> DeleteAsync(AudioLogic audio)
        {

            try
            {
                var audioDb = mapper.Map<AudioLogic, AudioDb>(audio);
                await dbmanager.RemoveAsync(audioDb);
                return Result.Ok();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbUpdateException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbEntityValidationException e)
            {
                return Result.Fail(e.Message);
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public async Task<Result> UpdateAsync(AudioLogic audio)
        {
            try
            {
                var audioDb = mapper.Map<AudioLogic, AudioDb>(audio);
                await dbmanager.UpdateAsync(audioDb);
                return Result.Ok();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbUpdateException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbEntityValidationException e)
            {
                return Result.Fail(e.Message);
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
