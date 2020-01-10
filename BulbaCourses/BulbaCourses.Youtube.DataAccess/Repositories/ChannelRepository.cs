using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.DataAccess.Models;

namespace BulbaCourses.Youtube.DataAccess.Repositories
{
    public class ChannelRepository : IChannelRepository
    {
        private YoutubeContext _context;
        private bool _isDisposed = false;

        public ChannelRepository(YoutubeContext ctx)
        {
            _context = ctx;
        }

        /// <summary>
        /// Save Channel 
        /// </summary>
        /// <param name="channel"></param>
        public ChannelDb Save(ChannelDb channel)
        {
            _context.Channels.Add(channel);
            _context.SaveChanges();
            return channel;
        }

        /// <summary>
        /// Get all Channels 
        /// </summary>
        /// <returns></returns>
        /// <summary>
        public IEnumerable<ChannelDb> GetAll()
        {
            return _context.Channels.ToList().AsReadOnly();
        }

        /// <summary>
        /// Get Channel by Id
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public ChannelDb GetById(string channelId)
        {
            return _context.Channels.SingleOrDefault(c => c.Id.Equals(channelId));
        }

        /// <summary>
        /// Delete Channel by Id
        /// </summary>
        /// <param name="channelId"></param>
        public void DeleteById(string channelId)
        {
            var delChannel = _context.Channels.SingleOrDefault(c => c.Id.Equals(channelId));
            if (delChannel != null)
            {
                _context.Channels.Remove(delChannel);
                _context.SaveChanges();
            }
        }
        /// <summary>
        /// Check if Channel exists
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public bool Exists(ChannelDb channel)
        {
            return _context.Channels.Any(c => c.Id.Equals(channel.Id));
        }

        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool flag)
        {
            if (_isDisposed) return;
            _context.Dispose();
            _isDisposed = true;

            if (flag)
                GC.SuppressFinalize(this);
        }
    }
}
