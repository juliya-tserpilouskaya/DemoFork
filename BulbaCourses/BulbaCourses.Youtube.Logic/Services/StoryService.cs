using BulbaCourses.Youtube.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.DataAccess.Models;
using BulbaCourses.Youtube.Logic.Models;
using AutoMapper;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using FluentValidation;

namespace BulbaCourses.Youtube.Logic.Services
{
    public class StoryService : IStoryService
    {
        IStoryRepository _storyRepository;
        readonly IMapper _mapper;
        private readonly IValidator<SearchStory> _validator;

        public StoryService(IStoryRepository storyRepository, IMapper mapper, IValidator<SearchStory> validator)
        {
            _storyRepository = storyRepository;
            _mapper = mapper;
            _validator = validator;
        }

        /// <summary>
        /// Save current search request as story for User
        /// </summary>
        /// <param name="story"></param>
        public SearchStory Save(SearchStory story)
        {
            var result = _validator.Validate(story, ruleSet: "AddStory");

            if(!result.IsValid)
                return story;

            var storyDb = _mapper.Map<SearchStoryDb>(story);
            
            return _mapper.Map<SearchStory>(_storyRepository.Save(storyDb));
        }

        public async Task<Result<SearchStory>> SaveAsync(SearchStory story)
        {
            //validation
            var result = _validator.Validate(story, ruleSet: "AddStory");
            if (!result.IsValid)
                return (Result<SearchStory>)Result.Fail($"Invalid model");


            var storyDb = _mapper.Map<SearchStoryDb>(story);
            _storyRepository.Save(storyDb);

            try
            {
                await _storyRepository.SaveChangeAsync();
                return Result<SearchStory>.Ok(_mapper.Map<SearchStory>(storyDb));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return (Result<SearchStory>)Result.Fail($"Cannot save model. {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                return (Result<SearchStory>)Result.Fail($"Cannot save model. {ex.Message}");
            }            
            catch (DbEntityValidationException ex)
            {
                return (Result<SearchStory>)Result.Fail($"Cannot save model. Invalid model. {ex.Message}");
            }
        }

        /// <summary>
        /// Delete all records story by User Id
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteByUserId(string userId)
        {
            if (userId != null)
                _storyRepository.DeleteByUserId(userId);
        }

        /// <summary>
        /// Delete all records story by User Id
        /// </summary>
        /// <param name="userId"></param>
        public async Task<Result> DeleteByUserIdAsync(string userId)
        {
            if (userId == null)
                return Result.Fail($"Invalid model");

            _storyRepository.DeleteByUserId(userId);

            try
            {
                await _storyRepository.SaveChangeAsync();
                return Result.Ok();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Result.Fail($"Cannot delete model. {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                return Result.Fail($"Cannot delete model. {ex.Message}");
            }
        }

        /// <summary>
        ///Delete one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        public void DeleteByStoryId(int? storyId)
        {
            if (storyId!=null)
                _storyRepository.DeleteByStoryId(storyId);
        }

        /// <summary>
        ///Delete one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        public async Task<Result> DeleteByStoryIdAsync(int? storyId)
        {
            if (storyId == null)
                return Result.Fail($"Invalid model");

            _storyRepository.DeleteByStoryId(storyId);

            try
            {
                await _storyRepository.SaveChangeAsync();
                return Result.Ok();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Result.Fail($"Cannot delete model. {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                return Result.Fail($"Cannot delete model. {ex.Message}");
            }
        }

        /// <summary>
        /// Get all stories for all Users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SearchStory> GetAllStories()
        {
            return _mapper.Map<IEnumerable<SearchStory>>(_storyRepository.GetAll());
        }

        public async Task<IEnumerable<SearchStory>> GetAllStoriesAsync()
        {
            return _mapper.Map<IEnumerable<SearchStory>>(await _storyRepository.GetAllAsync());
        }

        /// <summary>
        /// Get all stories by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<SearchStory> GetStoriesByUserId(string userId)
        {
            return _mapper.Map<IEnumerable<SearchStory>>(_storyRepository.GetByUserId(userId));
        }

        public async Task<IEnumerable<SearchStory>> GetStoriesByUserIdAsync(string userId)
        {
            return _mapper.Map<IEnumerable<SearchStory>>(await _storyRepository.GetByUserIdAsync(userId));
        }

        /// <summary>
        /// Get all stories by Request Id
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public IEnumerable<SearchStory> GetStoriesByRequestId(int? requestId)
        {
            return _mapper.Map<IEnumerable<SearchStory>>(_storyRepository.GetByRequestId(requestId));
        }

        public async Task<IEnumerable<SearchStory>> GetStoriesByRequestIdAsync(int? requestId)
        {
            return _mapper.Map<IEnumerable<SearchStory>>(await _storyRepository.GetByRequestIdAsync(requestId));            
        }

        /// <summary>
        /// Get one record from story by Story Id
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        public SearchStory GetStoryByStoryId(int? storyId)
        {
            return _mapper.Map<SearchStory>(_storyRepository.GetByStoryId(storyId));
        }

        public async Task<SearchStory> GetStoryByStoryIdAsync(int? storyId)
        {
            return _mapper.Map<SearchStory>(await _storyRepository.GetByStoryIdAsync(storyId));
        }

        public async Task<bool> ExistsAsync(int? storyId)
        {
            return await _storyRepository.ExistsAsync(storyId);
        }       
    }
}
