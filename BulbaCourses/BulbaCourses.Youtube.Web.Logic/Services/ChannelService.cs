using BulbaCourses.Youtube.Web.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.Web.DataAccess.Models;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    public class ChannelService : IChannelService
    {
        IChannelRepository _channelRepository;
        public ChannelService(IChannelRepository channelRepository)
        {
            _channelRepository = channelRepository;
        }

        /// <summary>
        /// Save Channel
        /// </summary>
        /// <param name="channel"></param>
        public ChannelDb Save(ChannelDb channel)
        {
            if (channel != null && !_channelRepository.Exists(channel))
                return _channelRepository.Save(channel);
            return channel;
        }

        /// <summary>
        /// Get all Channels
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ChannelDb> GetAllChannels()
        {
            return _channelRepository.GetAll();
        }

        /// <summary>
        /// Get Channel by Id
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public ChannelDb GetChannelById(string channelId)
        {
            return _channelRepository.GetById(channelId);
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
        /// Check if Channel exists
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public bool Exists(ChannelDb channel)
        {
            return _channelRepository.Exists(channel);
        }
    }
}
