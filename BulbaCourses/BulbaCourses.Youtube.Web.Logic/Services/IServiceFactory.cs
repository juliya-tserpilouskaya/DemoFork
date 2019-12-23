using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    public interface IServiceFactory
    {
        ICacheService CreateCacheService();
        IChannelService CreateChannelService();
        ISearchRequestService CreateSearchRequestService();
        IStoryService CreateStoryService();
        IUserService CreateUserService();
        IVideoService CreateVideoService();
    }
}
