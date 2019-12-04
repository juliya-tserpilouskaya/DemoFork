using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.Web.DataAccess.Repositories;
using BulbaCourses.Youtube.Web.Logic.Models;
using BulbaCourses.Youtube.Web.DataAccess.Models;
using Video = BulbaCourses.Youtube.Web.DataAccess.Models.Video;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    public class VideoService : IVideoService
    {
        IVideoRepository _videoRepository;
        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public VideoService()
        {
            _videoRepository = new VideoRepository();
        }


        public IEnumerable<string> GetSearchListResponse(string searchTerm)
        {
            // Create the service.
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyAZQwG0x87WljOsVjJGfL1fIC30EWf42pg",
                ApplicationName = "BulbaCourses"
            });

            // Run the request.
            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = searchTerm; // Replace with your search term.
            searchListRequest.MaxResults = 10;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = searchListRequest.Execute();

            List<string> videos = new List<string>();
            List<string> channels = new List<string>();
            List<string> playlists = new List<string>();
            List<string> urls = new List<string>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        videos.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
                        urls.Add(searchResult.Id.VideoId);
                        break;

                    case "youtube#channel":
                        channels.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
                        break;

                    case "youtube#playlist":
                        playlists.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
                        break;
                }
            }

            Console.WriteLine(String.Format("Videos:\n{0}\n", string.Join("\n", videos)));
            Console.WriteLine(String.Format("Channels:\n{0}\n", string.Join("\n", channels)));
            Console.WriteLine(String.Format("Playlists:\n{0}\n", string.Join("\n", playlists)));

            return videos.AsReadOnly();
        }

        public IEnumerable<Video> GetAll()
        {
            return _videoRepository.GetAll();
        }

        public Video GetById(int? id)
        {
            return _videoRepository.GetById(id);
        }
    }
}
