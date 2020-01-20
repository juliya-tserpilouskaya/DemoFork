using BulbaCourses.Youtube.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BulbaCourses.Youtube.DataAccess.Models;
using BulbaCourses.Youtube.Logic.Models;
using Castle.Core.Internal;

namespace BulbaCourses.Youtube.Logic.Services
{
    public class ChannelService : IChannelService
    {
        IChannelRepository _channelRepository;
        readonly IMapper _mapper;

        public ChannelService(IChannelRepository channelRepository, IMapper mapper)
        {
            _channelRepository = channelRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Save Channel
        /// </summary>
        /// <param name="channel"></param>
        public Channel Save(Channel channel)
        {
            var channelDb = _mapper.Map<ChannelDb>(channel);

            if (channelDb != null && !_channelRepository.Exists(channelDb))
                return _mapper.Map<Channel>(_channelRepository.Save(channelDb));
            return channel;
        }

        /// <summary>
        /// Save Channel Async
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public async Task<Result<Channel>> SaveAsync(Channel channel)
        {
            var channelDb = _mapper.Map<ChannelDb>(channel);
            _channelRepository.Save(channelDb);

            try
            {
                await _channelRepository.SaveChangeAsync();
                return Result<Channel>.Ok(_mapper.Map<Channel>(channelDb));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return (Result<Channel>)Result.Fail($"Cannot save model. {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                return (Result<Channel>)Result.Fail($"Cannot save model. {ex.Message}");
            }
            catch (DbEntityValidationException ex)
            {
                return (Result<Channel>)Result.Fail($"Cannot save model. Invalid model. {ex.Message}");
            }
        }

        /// <summary>
        /// Get all Channels
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Channel> GetAllChannels()
        {
            return _mapper.Map<IEnumerable<Channel>>(_channelRepository.GetAll());
        }

        /// <summary>
        /// Get Channel by Id
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public Channel GetChannelById(string channelId)
        {
            return _mapper.Map<Channel>(_channelRepository.GetById(channelId));
        }

        /// <summary>
        /// Delete Channel by Id
        /// </summary>
        /// <param name="channelId"></param>
        public void DeleteChannelById(string channelId)
        {
            if (channelId != null)
                _channelRepository.DeleteById(channelId);
        }

        /// <summary>
        /// Delete Channel by Id Async
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public async Task<Result> DeleteChannelByIdAsync(string channelId)
        {
            if (channelId.IsNullOrEmpty())
                return Result.Fail($"Invalid channel Id");

            _channelRepository.DeleteById(channelId);

            try
            {
                await _channelRepository.SaveChangeAsync();
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
        /// Check if Channel exists
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public bool Exists(Channel channel)
        {
            var channelDb = _mapper.Map<ChannelDb>(channel);
            return _channelRepository.Exists(channelDb);
        }
    }
}
