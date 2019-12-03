using BulbaCourse.Video.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourse.Video.Infrastructure.Interface
{
    public interface ICourseService
    {
        Course GetById(string id);
        IEnumerable<Course> GetAll();
        Course Add(Course course);
        List<VideoWeb> GetAllVideo(string courseId);
        VideoWeb AddVideo(string courseId, VideoWeb VideoWeb);
        Course Update(Course course);
        void Delete(Course course);
        void DeleteById(string courseId);
    }
}
