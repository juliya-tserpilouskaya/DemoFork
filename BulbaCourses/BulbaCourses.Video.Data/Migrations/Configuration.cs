namespace BulbaCourses.Video.Data.Migrations
{
    using BulbaCourses.Video.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BulbaCourses.Video.Data.DatabaseContext.VideoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BulbaCourses.Video.Data.DatabaseContext.VideoDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            #region Users
            var user1 = new UserDb()
            {
                UserId = Guid.NewGuid().ToString(),
                Login = "login1",
                SubscriptionType = 1
            };
            var user2 = new UserDb()
            {
                UserId = Guid.NewGuid().ToString(),
                Login = "login2",
                SubscriptionType = 1
            };
            context.Users.Add(user1);
            context.Users.Add(user2);
            #endregion

            #region Tags
            var tag1 = new TagDb()
            {
                TagId = Guid.NewGuid().ToString(),
                Content = "C#"
            };
            var tag2 = new TagDb()
            {
                TagId = Guid.NewGuid().ToString(),
                Content = "ASP.Net"
            };
            var tag3 = new TagDb()
            {
                TagId = Guid.NewGuid().ToString(),
                Content = "Java"
            };
            var tag4 = new TagDb()
            {
                TagId = Guid.NewGuid().ToString(),
                Content = "Automated"
            };
            var tag5 = new TagDb()
            {
                TagId = Guid.NewGuid().ToString(),
                Content = "Testing"
            };
            var tag6 = new TagDb()
            {
                TagId = Guid.NewGuid().ToString(),
                Content = "Network"
            };
            context.Tags.Add(tag1);
            context.Tags.Add(tag2);
            context.Tags.Add(tag3);
            context.Tags.Add(tag4);
            context.Tags.Add(tag5);
            context.Tags.Add(tag6);
            #endregion

            #region Authors
            var author1 = new AuthorDb()
            {
                AuthorId = Guid.NewGuid().ToString(),
                Name = "Aleksandr",
                Lastname = "Shaduro",
                Annotation = "Experienced Instructor with a demonstrated history of working in the higher education industry. " +
                "Skilled in WEB Development, Agile Methodologies. Strong education professional graduated from Belarusian State University",
                Professions = "Chief Technical Officer at Artooba"
            };
            var author2 = new AuthorDb()
            {
                AuthorId = Guid.NewGuid().ToString(),
                Name = "Aleksandr",
                Lastname = "Korablin",
                Annotation = "MCSD: MICROSOFT CERTIFIED SOLUTION DEVELOPER, ORACLE CERTIFIED ASSOCIATE, " +
                "JAVA SE 7 PROGRAMMER, WINDOWS AZURE DEVELOPER, MICROSOFT CERTIFIED TRAINER",
                Professions = "MICROSOFT CERTIFIED SOLUTION DEVELOPER"
            };
            var author3 = new AuthorDb()
            {
                AuthorId = Guid.NewGuid().ToString(),
                Name = "Aleksandr",
                Lastname = "Borovoy",
                Annotation = "Local network, DHCP, DNS, NOD-32",
                Professions = "Local network"
            };
            context.Authors.Add(author1);
            context.Authors.Add(author2);
            context.Authors.Add(author3);
            #endregion

            #region Courses
            var course1 = new CourseDb()
            {
                CourseId = Guid.NewGuid().ToString(),
                Name = "ASP by Shaduro",
                Author = author1,
                Level = 1,
                Raiting = 5,
                RateCount = 20,
                Description = ".NET is a developer platform made up of tools, programming languages, and libraries for building many different types of applications." +
                "ASP.NET extends the.NET developer platform with tools and libraries specifically for building web apps.",
                Date = DateTime.Now,
                Price = 850
            };
            //course1.Tags.Add(tag1);
            //course1.Tags.Add(tag2);

            var course2 = new CourseDb()
            {
                CourseId = Guid.NewGuid().ToString(),
                Name = "Programming in C#",
                Author = author1,
                Level = 1,
                Raiting = 4,
                RateCount = 12,
                Description = "C#(Sharp) is an object-oriented programming language developed by Microsoft.",
                Date = DateTime.Now,
                Price = 50
            };
            //course2.Tags.Add(tag1);

            var course3 = new CourseDb()
            {
                CourseId = Guid.NewGuid().ToString(),
                Name = "Java for Automated Testing",
                Author = author2,
                Level = 1,
                Raiting = 4,
                RateCount = 10,
                Description = "Test automation, a formalized testing process, can automate repetitive but necessary tasks that would be difficult to do manually.",
                Date = DateTime.Now,
                Price = 70
            };
            //course3.Tags.Add(tag3);
            //course3.Tags.Add(tag4);
            //course3.Tags.Add(tag5);

            var course4 = new CourseDb()
            {
                CourseId = Guid.NewGuid().ToString(),
                Name = "Local Network",
                Author = author3,
                Level = 1,
                Raiting = 3,
                RateCount = 6,
                Description = "A local area network (LAN) is a computer network that interconnects computers within a limited area.",
                Date = DateTime.Now,
                Price = 10
            };
            //course4.Tags.Add(tag6);

            context.Courses.Add(course1);
            context.Courses.Add(course2);
            context.Courses.Add(course3);
            context.Courses.Add(course4);
            #endregion

            #region Videos
            var video1 = new VideoMaterialDb()
            {
                VideoId = Guid.NewGuid().ToString(),
                Name = "validation",
                Url = @"D:\TestCourses\ASP by Shaduro\1_video_validation.mp4",
                Created = DateTime.Now,
                NumberOfViews = 1,
                Order = 1,
                CourseId = course1.CourseId
            };
            var video2 = new VideoMaterialDb()
            {
                VideoId = Guid.NewGuid().ToString(),
                Name = "Refactiring & Security",
                Url = @"D:\TestCourses\ASP by Shaduro\2_video_refactiring_&_security.mp4",
                Created = DateTime.Now,
                NumberOfViews = 1,
                Order = 2,
                CourseId = course1.CourseId
            };
            var video3 = new VideoMaterialDb()
            {
                VideoId = Guid.NewGuid().ToString(),
                Name = "Angular_Basic",
                Url = @"D:\TestCourses\ASP by Shaduro\3_video_angular_basic.mp4",
                Created = DateTime.Now,
                NumberOfViews = 1,
                Order = 3,
                CourseId = course1.CourseId
            };
            var video4 = new VideoMaterialDb()
            {
                VideoId = Guid.NewGuid().ToString(),
                Name = "C# start part.1",
                Url = @"D:\TestCourses\Programming in C#\1_1_x264.mp4",
                Created = DateTime.Now,
                NumberOfViews = 1,
                Order = 1,
                CourseId = course2.CourseId
            };
            var video5 = new VideoMaterialDb()
            {
                VideoId = Guid.NewGuid().ToString(),
                Name = "C# start part.1",
                Url = @"D:\TestCourses\Programming in C#\1_2_x264.mp4",
                Created = DateTime.Now,
                NumberOfViews = 1,
                Order = 2,
                CourseId = course2.CourseId
            };
            var video6 = new VideoMaterialDb()
            {
                VideoId = Guid.NewGuid().ToString(),
                Name = "Java Fundamentals",
                Url = @"D:\TestCourses\Java for Automated Testing\01_Java Fundamentals.wmv",
                Created = DateTime.Now,
                NumberOfViews = 1,
                Order = 1,
                CourseId = course3.CourseId
            };
            var video7 = new VideoMaterialDb()
            {
                VideoId = Guid.NewGuid().ToString(),
                Name = "Object Oriented Programming",
                Url = @"D:\TestCourses\Java for Automated Testing\02_Object Oriented Programming.wmv",
                Created = DateTime.Now,
                NumberOfViews = 1,
                Order = 2,
                CourseId = course3.CourseId
            };
            var video8 = new VideoMaterialDb()
            {
                VideoId = Guid.NewGuid().ToString(),
                Name = "Numbers, strings, dates",
                Url = @"D:\TestCourses\Java for Automated Testing\03_Numbers, strings, dates.avi",
                Created = DateTime.Now,
                NumberOfViews = 1,
                Order = 3,
                CourseId = course3.CourseId
            };
            var video9 = new VideoMaterialDb()
            {
                VideoId = Guid.NewGuid().ToString(),
                Name = "Вводный урок",
                Url = @"D:\TestCourses\Локальная компьютерная сеть\Урок 1 — Вводный урок.avi",
                Created = DateTime.Now,
                NumberOfViews = 1,
                Order = 1,
                CourseId = course4.CourseId
            };
            var video10 = new VideoMaterialDb()
            {
                VideoId = Guid.NewGuid().ToString(),
                Name = "Закрытая серверная стойка",
                Url = @"D:\TestCourses\Локальная компьютерная сеть\Урок 2 — Обзор закрытой серверной стойки.avi",
                Created = DateTime.Now,
                NumberOfViews = 1,
                Order = 2,
                CourseId = course4.CourseId
            };

            context.VideoMaterials.Add(video1);
            context.VideoMaterials.Add(video2);
            context.VideoMaterials.Add(video3);
            context.VideoMaterials.Add(video4);
            context.VideoMaterials.Add(video5);
            context.VideoMaterials.Add(video6);
            context.VideoMaterials.Add(video7);
            context.VideoMaterials.Add(video8);
            context.VideoMaterials.Add(video9);
            context.VideoMaterials.Add(video10);
            #endregion

            context.SaveChanges();

        }
    }
}
