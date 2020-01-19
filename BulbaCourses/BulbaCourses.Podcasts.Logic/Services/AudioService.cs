using AutoMapper;
using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

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

        public Result Add(AudioLogic audio, CourseLogic course)
        {
            try
            {
                audio.Course = course;
                audio.Id = Guid.NewGuid().ToString();
                var audioDb = mapper.Map<AudioLogic, AudioDb>(audio);
                var result = dbmanager.Add(audioDb);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }

        }

        public Result<AudioLogic> GetById(string Id)
        {
            try
            {
                var audio = dbmanager.GetById(Id).GetAwaiter().GetResult();
                var AudioLogic = mapper.Map<AudioDb, AudioLogic>(audio);
                return Result<AudioLogic>.Ok(AudioLogic);
            }
            catch (Exception)
            {
                return Result<AudioLogic>.Fail("Exception");
            }
        }

        public Result<IEnumerable<AudioLogic>> Search(string Name)
        {
            try
            {
                var audio = dbmanager.GetAll().GetAwaiter().GetResult().Where(c => c.Name.Contains(Name)).ToList();
                var AudioLogic = mapper.Map<IEnumerable<AudioDb>, IEnumerable<AudioLogic>>(audio);
                return Result<IEnumerable<AudioLogic>>.Ok(AudioLogic);
            }
            catch (Exception)
            {
                return Result<IEnumerable<AudioLogic>>.Fail("Exception");
            }
        }

        public Result<IEnumerable<AudioLogic>> GetAll()
        {
            try
            {
                var audios = dbmanager.GetAll().GetAwaiter().GetResult();
                var result = mapper.Map<IEnumerable<AudioDb>, IEnumerable<AudioLogic>>(audios);
                return Result<IEnumerable<AudioLogic>>.Ok(result);
            }
            catch (Exception)
            {
                return Result<IEnumerable<AudioLogic>>.Fail("Exception");
            }
        }

        public Result Delete(AudioLogic audio)
        {

            try
            {
                var audioDb = mapper.Map<AudioLogic, AudioDb>(audio);
                dbmanager.Remove(audioDb);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public Result Update(AudioLogic audio)
        {
            try
            {
                var audioDb = mapper.Map<AudioLogic, AudioDb>(audio);
                dbmanager.Update(audioDb);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public bool Exists(string name)
        {
            return dbmanager.GetAll().GetAwaiter().GetResult().Any(b => b.Name == name);
        }
    }
}
