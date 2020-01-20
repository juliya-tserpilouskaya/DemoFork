using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.DataAccess.Models;
using BulbaCourses.Youtube.Logic.Models;

namespace BulbaCourses.Youtube.Logic.Services
{
    public interface IChannelService
    {
        /// <summary>
        /// Save Channel
        /// </summary>
        /// <param name="channel"></param>
        Channel Save(Channel channel);

        /// <summary>
        /// Save Channel Async
        /// </summary>
        /// <param name="story"></param>
        /// <returns></returns>
        Task<Result<Channel>> SaveAsync(Channel story);

        /// <summary>
        /// Get all Channels
        /// </summary>
        /// <returns></returns>
        IEnumerable<Channel> GetAllChannels();

        /// <summary>
        /// Get Channel by Id
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        Channel GetChannelById(string channelId);

        /// <summary>
        /// Delete Channel by Id
        /// </summary>
        /// <param name="channelId"></param>
        void DeleteChannelById(string channelId);

        /// <summary>
        /// Delete Channel by Id Async
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        Task<Result> DeleteChannelByIdAsync(string channelId);

        /// <summary>
        /// Check if Channel exists
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        bool Exists(Channel channel);
    }
}
