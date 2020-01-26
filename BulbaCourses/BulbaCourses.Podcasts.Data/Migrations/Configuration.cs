namespace BulbaCourses.Podcasts.Data.Migrations
{
    using BulbaCourses.Podcasts.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Ninject;
    using BulbaCourses.Podcasts.Data.Managers;
    using System.Threading.Tasks;

    internal sealed class Configuration : DbMigrationsConfiguration<BulbaCourses.Podcasts.Data.PodcastsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BulbaCourses.Podcasts.Data.PodcastsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var course1 = new CourseDb()
            {
                Id = "0",
                Name = "TestName",
                Raiting = 0,
                Description = "test",
                Duration = 13,
                Price = 13,
            };
            var user1 = new UserDb()
            {
                Id = "0",
                IsAdmin = true,
                Name = "TestUser",
            };

            var audio1 = new AudioDb()
            {
                Id = "0",
                Name = "Test",
                Duration = 13
            };
            var comment1 = new CommentDb()
            {
                Id = "0",
                Text = "TestComment",
            };
            var content1 = new ContentDb()
            {
                Id = "0",
                Data = "qwerty"
            };

            course1.Author = user1;
            audio1.Course = course1;
            comment1.User = user1;
            comment1.Course = course1;
            audio1.Content = content1.Id;

            course1.Audios.Add(audio1);
            course1.Comments.Add(comment1);
            user1.UploadedCourses.Add(course1);

            context.Courses.Add(course1);
            context.Audios.Add(audio1);
            context.Comments.Add(comment1);
            context.Users.Add(user1);
            context.Courses.Add(course1);

            var man = new ContentManager(new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter());
            Task.FromResult(man.AddAsync(content1));
            

            base.Seed(context);
        }
    }
}
