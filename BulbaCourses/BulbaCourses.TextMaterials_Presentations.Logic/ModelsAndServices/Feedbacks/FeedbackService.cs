using System;
using AutoMapper;
using System.Collections.Generic;
using System.Text;
using Fody;
using Presentations.Logic.Interfaces;
using Presentations.Logic.Repositories;
using BulbaCourses.TextMaterials_Presentations.Data;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using Presentations.Logic.Models;

namespace Presentations.Logic.Services
{
    public class FeedbackService : IFeedbacksService
    {
        private IUnitOfWorkRepository _uow;
        private readonly IMapper _mapper;

        public FeedbackService(IUnitOfWorkRepository uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        /// <summary>
        /// Map FeedbackAdd_DTO to FeedbackDB, passes to Add DB-method the FeedbackDB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result<Feedback>> AddFeedbackAsync(FeedbackAdd_DTO model)
        {
            var feedbackDb = _mapper.Map<FeedbackAdd_DTO, FeedbackDB>(model);
            _uow.Feedbacks.Add(feedbackDb);

            try
            {
                await _uow.SaveAsync();
                return Result<Feedback>.Ok(_mapper.Map<Feedback>(feedbackDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<Feedback>)Result<Feedback>.Fail("Cannot save model");
            }
            catch (DbUpdateException e)
            {
                return (Result<Feedback>)Result<Feedback>.Fail($"Cannot save model. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<Feedback>)Result<Feedback>.Fail("Invalid model");
            }
        }

        /// <summary>
        /// Map FeedbackDB to Feedback, passes to GetByIdAsync DB-method the id for getting feedback
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Feedback> GetFeedbackByIdAsync(string id)
        {
            var feedback = await _uow.Feedbacks.GetByIdAsync(id);
            return _mapper.Map<FeedbackDB, Feedback>(feedback);
        }

        /// <summary>
        /// Map FeedbackDB to Feedback, get all courses from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Feedback>> GetAllFeedbacksAsync()
        {
            var feedbacks = await _uow.Feedbacks.GetAllAsync();
            return _mapper.Map<IEnumerable<FeedbackDB>, IEnumerable<Feedback>>(feedbacks);
        }

        /// <summary>
        /// Map Feedback to FeedbackDB, passes to Update DB-method the FeedbackDB for updating
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result<Feedback>> UpdateFeedbackAsync(Feedback model)
        {
            var feedbackDb = _mapper.Map<Feedback, FeedbackDB>(model);
            _uow.Feedbacks.Update(feedbackDb);

            try
            {
                await _uow.SaveAsync();
                return Result<Feedback>.Ok(_mapper.Map<Feedback>(feedbackDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<Feedback>)Result<Feedback>.Fail("Cannot update model");
            }
            catch (DbUpdateException e)
            {
                return (Result<Feedback>)Result<Feedback>.Fail($"Cannot update model. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<Feedback>)Result<Feedback>.Fail("Invalid model");
            }
        }

        /// <summary>
        /// Passes to DeleteById DB-method the id for deletion FeedbackDB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> DeleteFeedbackByIdAsync(string id)
        {
            _uow.Feedbacks.DeleteById(id);

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

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}