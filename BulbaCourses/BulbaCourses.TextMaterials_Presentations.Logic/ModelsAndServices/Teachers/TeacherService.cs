using AutoMapper;
using BulbaCourses.TextMaterials_Presentations.Data;
using Presentations.Logic.Interfaces;
using Presentations.Logic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Presentations.Logic.Repositories
{
    public class TeacherService : ITeacherService
    {
        private IUnitOfWorkRepository _uow;
        private readonly IMapper _mapper;

        public TeacherService(IUnitOfWorkRepository uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        /// <summary>
        /// Map UserAdd_DTO to TeacherDB, passes to Add DB-method the TeacherDB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result<Teacher>> AddTeacherAsync(TeacherAdd_DTO model)
        {
            var teacherDb = _mapper.Map<TeacherAdd_DTO, TeacherDB>(model);
            _uow.Teachers.Add(teacherDb);

            try
            {
                await _uow.SaveAsync();
                return Result<Teacher>.Ok(_mapper.Map<Teacher>(teacherDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<Teacher>)Result<Teacher>.Fail("Cannot save model");
            }
            catch (DbUpdateException e)
            {
                return (Result<Teacher>)Result<Teacher>.Fail($"Cannot save model. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<Teacher>)Result<Teacher>.Fail("Invalid model");
            }
        }

        /// <summary>
        /// Map TeacherDB to Teacher, passes to GetByIdAsync DB-method the id for getting teacher
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Teacher> GetTeacherByIdAsync(string id)
        {
            var teacher = await _uow.Teachers.GetByIdAsync(id);
            return _mapper.Map<TeacherDB, Teacher>(teacher);
        }

        /// <summary>
        /// Map TeacherDB to Teacher, get all teachers from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            var teachers = await _uow.Teachers.GetAllAsync();
            return _mapper.Map<IEnumerable<TeacherDB>, IEnumerable<Teacher>>(teachers);
        }

        /// <summary>
        /// Map Teacher to TeacherDB, passes to Update DB-method the TeacherDB for updating
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result<Teacher>> UpdateTeacherAsync(Teacher model)
        {
            var teacherDb = _mapper.Map<Teacher, TeacherDB>(model);
            _uow.Teachers.Update(teacherDb);

            try
            {
                await _uow.SaveAsync();
                return Result<Teacher>.Ok(_mapper.Map<Teacher>(teacherDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<Teacher>)Result<Teacher>.Fail("Cannot update model");
            }
            catch (DbUpdateException e)
            {
                return (Result<Teacher>)Result<Teacher>.Fail($"Cannot update model. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<Teacher>)Result<Teacher>.Fail("Invalid model");
            }
        }

        /// <summary>
        /// Passes to DeleteById DB-method the id for deletion TeacherDB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> DeleteTeacherByIdAsync(string id)
        {
            _uow.Teachers.DeleteById(id);

            try
            {
                await _uow.SaveAsync();
                return await Task.FromResult(Result.Ok());
            }
            catch (DbUpdateConcurrencyException e)
            {
                return await Task.FromResult(Result.Fail("Cannot delete model"));
            }
            catch (DbUpdateException e)
            {
                return await Task.FromResult(Result.Fail($"Cannot delete model. Duplicate field. {e.Message}"));
            }
            catch (DbEntityValidationException e)
            {
                return await Task.FromResult(Result.Fail("Invalid id"));
            }
        }

        /// <summary>
        /// Checks exist the same userIdIdentity in the database or not
        /// </summary>
        /// <param name="userIdIdentity"></param>
        /// <returns></returns>
        public async Task<bool> ExistTeacherAsync(string userIdIdentity)
        {
            return await _uow.Context.Teachers.AnyAsync(b => b.Id == userIdIdentity).ConfigureAwait(false);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacksFromTeacherAsync(string id)
        {
            var teacher = await _uow.TeacherLoading.GetAllFeedbacksFromTeacherAsync(id);
            return _mapper.Map<IEnumerable<FeedbackDB>, IEnumerable<Feedback>>(teacher.Feedbacks);
        }

        public async Task<IEnumerable<Presentation>> GetAllChangedPresentationsAsync(string id)
        {
            var teacher = await _uow.TeacherLoading.GetAllChangedPresentationsAsync(id);
            return _mapper.Map<IEnumerable<PresentationDB>, IEnumerable<Presentation>>(teacher.ChangedPresentatons);
        }
    }
}