using Presentations.Logic.Repositories;
using Presentations.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Presentations.Logic.Models;
using BulbaCourses.TextMaterials_Presentations.Data;
using AutoMapper;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.Entity;

namespace Presentations.Logic.Services
{
    public class StudentService : IStudentService
    {
        private IUnitOfWorkRepository _uow;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWorkRepository uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        /// <summary>
        /// Map UserAdd_DTO to StudentDB, passes to Add DB-method the StudentDB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result<Student>> AddStudentAsync(UserAdd_DTO model)
        {
            var studentDb = _mapper.Map<UserAdd_DTO, StudentDB>(model);
            _uow.Students.Add(studentDb);

            try
            {
                await _uow.SaveAsync();
                return Result<Student>.Ok(_mapper.Map<Student>(studentDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<Student>)Result<Student>.Fail("Cannot save model");
            }
            catch (DbUpdateException e)
            {
                return (Result<Student>)Result<Student>.Fail($"Cannot save model. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<Student>)Result<Student>.Fail("Invalid model");
            }
        }

        /// <summary>
        /// Map StudentDB to Student, passes to GetByIdAsync DB-method the id for getting student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Student> GetStudentByIdAsync(string id)
        {
            var student = await _uow.Students.GetByIdAsync(id);
            return _mapper.Map<StudentDB, Student>(student);
        }

        /// <summary>
        /// Map StudentDB to Student, get all students from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            var students = await _uow.Students.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDB>, IEnumerable<Student>>(students);
        }

        /// <summary>
        /// Map Student to StudentDB, passes to Update DB-method the StudentDB for updating
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result<Student>> UpdateStudentAsync(Student model)
        {
            var studentDb = _mapper.Map<Student, StudentDB>(model);
            _uow.Students.Update(studentDb);

            try
            {
                await _uow.SaveAsync();
                return Result<Student>.Ok(_mapper.Map<Student>(studentDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<Student>)Result<Student>.Fail("Cannot update model");
            }
            catch (DbUpdateException e)
            {
                return (Result<Student>)Result<Student>.Fail($"Cannot update model. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<Student>)Result<Student>.Fail("Invalid model");
            }
        }

        /// <summary>
        /// Passes to DeleteById DB-method the id for deletion StudentDB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> DeleteStudentByIdAsync(string id)
        {
            _uow.Students.DeleteById(id);

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
        public async Task<bool> ExistStudentAsync(string userIdIdentity)
        {
            return await _uow.Context.Students.AnyAsync(b => b.Id == userIdIdentity).ConfigureAwait(false);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }

        public async Task<Result> AddLovedPresentationAsync(string idStudent, string idPresentation)
        {
            _uow.StudentLoading.AddLovedPresentationAsync(idStudent, idPresentation);

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

        public async Task<Result> DeleteLovedPresentationAsync(string idStudent, string idPresentation)
        {
            _uow.StudentLoading.DeleteLovedPresentationAsync(idStudent, idPresentation);

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

        public async Task<IEnumerable<Presentation>> GetAllLovedPresentationAsync(string id)
        {
            var student = await _uow.StudentLoading.GetAllLovedPresentationAsync(id);
            return _mapper.Map<IEnumerable<PresentationDB>, IEnumerable<Presentation>>(student.FavoritePresentations);
        }

        public async Task<Result> AddWatchedPresentationAsync(string idStudent, string idPresentation)
        {
            _uow.StudentLoading.AddWatchedPresentationAsync(idStudent, idPresentation);

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

        public async Task<Result> DeleteWatchedPresentationAsync(string idStudent, string idPresentation)
        {
            _uow.StudentLoading.DeleteWatchedPresentationAsync(idStudent, idPresentation);

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

        public async Task<IEnumerable<Presentation>> GetAllWatchedPresentationAsync(string id)
        {
            var student = await _uow.StudentLoading.GetAllWatchedPresentationAsync(id);
            return _mapper.Map<IEnumerable<PresentationDB>, IEnumerable<Presentation>>(student.ViewedPresentations);
        }

        public async Task<Result> UpdateIsPaidAsync(string id, bool hasPayment)
        {
            await _uow.StudentLoading.UpdateIsPaidAsync(id, hasPayment);

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

        public async Task<IEnumerable<Feedback>> GetAllFeedbacksFromStudentAsync(string id)
        {
            var student = await _uow.StudentLoading.GetAllFeedbacksFromStudentAsync(id);
            return _mapper.Map<IEnumerable<FeedbackDB>, IEnumerable<Feedback>>(student.Feedbacks);
        }
    }
}
