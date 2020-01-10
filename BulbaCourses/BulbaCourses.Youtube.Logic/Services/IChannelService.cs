using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.DataAccess.Models;

namespace BulbaCourses.Youtube.Logic.Services
{
    public interface IChannelService
    {
        /// <summary>
        /// Save Channel
        /// </summary>
        /// <param name="channel"></param>
        ChannelDb Save(ChannelDb channel);

        /// <summary>
        /// Get all Channels
        /// </summary>
        /// <returns></returns>
        IEnumerable<ChannelDb> GetAllChannels();

        /// <summary>
        /// Get Channel by Id
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        ChannelDb GetChannelById(string channelId);

        /// <summary>
        /// Delete Channel by Id
        /// </summary>
        /// <param name="channelId"></param>
        void DeleteChannelById(string channelId);

        /// <summary>
        /// Check if Channel exists
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        bool Exists(ChannelDb channel);
    }
}
