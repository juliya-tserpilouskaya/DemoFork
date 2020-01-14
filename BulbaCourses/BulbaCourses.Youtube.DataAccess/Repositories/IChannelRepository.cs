using BulbaCourses.Youtube.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Youtube.DataAccess.Repositories
{
    public interface IChannelRepository : IDisposable
    {
        /// <summary>
        /// Save Changes Async
        /// </summary>
        /// <returns></returns>
        /// <summary>
        Task SaveChangeAsync();

        /// <summary>
        /// Save Channel 
        /// </summary>
        /// <param name="channel"></param>
        ChannelDb Save(ChannelDb channel);

        /// <summary>
        /// Get all Channels 
        /// </summary>
        /// <returns></returns>
        /// <summary>
        IEnumerable<ChannelDb> GetAll();

        /// <summary>
        /// Get Channel by Id
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        ChannelDb GetById(string channelId);

        /// <summary>
        /// Delete Channel by Id
        /// </summary>
        /// <param name="channelId"></param>
        void DeleteById(string channelId);

        /// <summary>
        /// Check if Channel exists
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        bool Exists(ChannelDb channel);
    }
}
