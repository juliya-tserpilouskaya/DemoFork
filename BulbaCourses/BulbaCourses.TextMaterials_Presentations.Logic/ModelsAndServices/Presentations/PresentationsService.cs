using System;
using AutoMapper;
using System.Collections.Generic;
using System.Text;
using Presentations.Logic.Interfaces;
using Presentations.Logic.Repositories;
using BulbaCourses.TextMaterials_Presentations.Data;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Threading;
using FluentValidation;
using Presentations.Logic.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace Presentations.Logic.Services
{
    public class PresentationsService : IPresentationsService
    {
        private IUnitOfWorkRepository _uow;
        private readonly IMapper _mapper;

        public PresentationsService(IUnitOfWorkRepository uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        /// <summary>
        /// Map PresentationAdd_DTO to PresentationDB, passes to Add DB-method the PresentationDB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result<Presentation>> AddPresentationAsync(PresentationAdd_DTO model)
        {
            var presentationDb = _mapper.Map<PresentationAdd_DTO, PresentationDB>(model);
            _uow.Presentations.Add(presentationDb);

            try
            {
                await _uow.SaveAsync();
                return Result<Presentation>.Ok(_mapper.Map<Presentation>(presentationDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<Presentation>)Result<Presentation>.Fail("Cannot save model");
            }
            catch (DbUpdateException e)
            {
                return (Result<Presentation>)Result<Presentation>.Fail($"Cannot save model. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<Presentation>)Result<Presentation>.Fail("Invalid model");
            }
        }

        /// <summary>
        /// Map PresentationDB to Presentation, passes to GetByIdAsync DB-method the id for getting presentation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Presentation> GetPresentationByIdAsync(string id)
        {
            var presentation = await _uow.Presentations.GetByIdAsync(id);
            return _mapper.Map<PresentationDB, Presentation>(presentation);
        }

        /// <summary>
        /// Map PresentationDB to Presentation, get all courses from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Presentation>> GetAllPresentationsAsync()
        {
            var presentations = await _uow.Presentations.GetAllAsync();
            return _mapper.Map<IEnumerable<PresentationDB>, IEnumerable<Presentation>>(presentations);
        }

        /// <summary>
        /// Map Presentation to PresentationDB, passes to Update DB-method the PresentationDB for updating
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result<Presentation>> UpdatePresentationAsync(Presentation model)
        {
            var presentationDb = _mapper.Map<Presentation, PresentationDB>(model);
            _uow.Presentations.Update(presentationDb);

            try
            {
                await _uow.SaveAsync();
                return Result<Presentation>.Ok(_mapper.Map<Presentation>(presentationDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<Presentation>)Result<Presentation>.Fail("Cannot update model");
            }
            catch (DbUpdateException e)
            {
                return (Result<Presentation>)Result<Presentation>.Fail($"Cannot update model. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<Presentation>)Result<Presentation>.Fail("Invalid model");
            }
        }

        /// <summary>
        /// Passes to DeleteById DB-method the id for deletion PresentationDB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> DeletePresentationByIdAsync(string id)
        {
            _uow.Presentations.DeleteById(id);

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
        /// Checks exist the same title in the database or not
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<bool> ExistPresentationAsync(string title)
        {
            return await _uow.Context.Presentations.AnyAsync(b => b.Title == title).ConfigureAwait(false);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }

        public async Task<IEnumerable<Student>> GetAllWhoWatchedThisPresentationAsync(string id)
        {
            var presentation = await _uow.PresentationsLoading.GetAllWhoWatchedThisPresentationAsync(id);
            return _mapper.Map<IEnumerable<StudentDB>, IEnumerable<Student>>(presentation.ViewedByStudents);
        }

        public async Task<IEnumerable<Student>> GetAllWhoLikeThisPresentationAsync(string id)
        {
            var presentation = await _uow.PresentationsLoading.GetAllWhoLikeThisPresentationAsync(id);
            return _mapper.Map<IEnumerable<StudentDB>, IEnumerable<Student>>(presentation.Students);
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacksPresentationAsync(string id)
        {
            var presentation = await _uow.PresentationsLoading.GetAllFeedbacksPresentationAsync(id);
            return _mapper.Map<IEnumerable<FeedbackDB>, IEnumerable<Feedback>>(presentation.Feedbacks);
        }
    }
}
