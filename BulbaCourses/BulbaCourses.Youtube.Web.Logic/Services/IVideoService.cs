using BulbaCourses.Youtube.Web.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    public interface IVideoService
    {
        IEnumerable<string> GetSearchListResponse(string searchTerm);
        IEnumerable<Video> GetAll();
        Video GetById(int? id);

    }
}
