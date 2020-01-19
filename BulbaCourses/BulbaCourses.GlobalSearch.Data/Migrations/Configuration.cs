namespace BulbaCourses.GlobalSearch.Data.Migrations
{
    using BulbaCourses.GlobalSearch.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BulbaCourses.GlobalSearch.Data.GlobalSearchContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BulbaCourses.GlobalSearch.Data.GlobalSearchContext";
        }

        protected override void Seed(BulbaCourses.GlobalSearch.Data.GlobalSearchContext context)
        {
            //  This method will be called after migrating to the latest version.
            var user1 = new UserDB()
            {
                Id = Guid.NewGuid().ToString(),
                Authorization = true,
            };

            var user2 = new UserDB()
            {
                Id = Guid.NewGuid().ToString(),
                Authorization = false,
            };

            #region Users
            context.Users.Add(user1);
            context.Users.Add(user2);
            #endregion

            #region SearchQueriesSeed
            context.SearchQueries.AddOrUpdate(x => x.Id,
                new SearchQueryDB
                {
                    Id = Guid.NewGuid().ToString(),
                    Query = "basics of c#",
                    Created = DateTime.Now,
                    UserId = user1.Id
                },
                new SearchQueryDB
                {
                    Id = Guid.NewGuid().ToString(),
                    Query = "c# advanced",
                    Created = DateTime.Now,
                    UserId = user1.Id
                },
                new SearchQueryDB
                {
                    Id = Guid.NewGuid().ToString(),
                    Query = "php 9 podcast",
                    Created = DateTime.Now,
                    UserId = user2.Id
                },
                new SearchQueryDB
                {
                    Id = Guid.NewGuid().ToString(),
                    Query = "develop c++",
                    Created = DateTime.Now,
                    UserId = user2.Id
                },
                new SearchQueryDB
                {
                    Id = Guid.NewGuid().ToString(),
                    Query = "terminator 3",
                    Created = DateTime.Now,
                    UserId = user2.Id,
                }
            );
            #endregion
            #region AuthorsSeed
            context.Authors.AddOrUpdate(x => x.Id,
                new AuthorDB() { Id = 1, Name = "Master Yoda"},
                new AuthorDB() { Id = 2, Name = "Richter"},
                new AuthorDB() { Id = 3, Name = "Skeet"},
                new AuthorDB() { Id = 4, Name = "Troelsen"}
            );
            #endregion
            #region CategoriesSeed
            context.Categories.AddOrUpdate(x => x.Id,
                new CourseCategoryDB()
                {
                    Id = 0,
                    Name = "Video",
                    Description = "Video learning materials on different topics"
                },
                new CourseCategoryDB()
                {
                    Id = 1,
                    Name = "Podcast",
                    Description = "Podcast learning materials on different topics"
                },
                new CourseCategoryDB()
                {
                    Id = 2,
                    Name = "Text",
                    Description = "Text learning materials on different topics"
                },
                new CourseCategoryDB()
                {
                    Id = 3,
                    Name = "Excercise",
                    Description = "Excercise learning materials on different topics"
                },
                new CourseCategoryDB()
                {
                    Id = 4,
                    Name = "Test",
                    Description = "Test learning materials on different topics"
                },
                new CourseCategoryDB()
                {
                    Id = 5,
                    Name = "Other",
                    Description = "Other learning materials on different topics"
                }
            );
            #endregion

            var course = new CourseDB()
            {
                AuthorDBId = 1,
                CourseCategoryDBId = 1,
                Id = Guid.NewGuid().ToString(),
                Name = "C++ video course",
                Description = "Full c++ video course in 2k",
            };

            var courseItem = new CourseItemDB()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Video 122",
                Description = "Vide2o 2 one description",
                Url = "https://sdf.com",
                CourseDBId = course.Id
            };

            var courseItem2 = new CourseItemDB()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Video 122",
                Description = "Vide2o 2 one description",
                Url = "https://sdf.com",
                CourseDBId = course.Id
            };

            

            var bookmark1 = new BookmarkDB()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user1.Id.ToString(),
                Title = "Best course ever5",
                URL = "https://sdf.com"
            };

            var bookmark2 = new BookmarkDB()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user1.Id.ToString(),
                Title = "Best course ever 7",
                URL = "https://sdf.com"
            };

            //var searchQuery1 = new SearchQueryDB()
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    UserId = user1.Id.ToString(),
            //    Query = "C# course"
            //};

            //var searchQuery2 = new SearchQueryDB()
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    UserId = user1.Id.ToString(),
            //    Query = "C++ course"
            //};

            //var searchQuery3 = new SearchQueryDB()
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    UserId = user2.Id.ToString(),
            //    Query = "JS course"
            //};


            #region CoursesSeed
            context.Courses.Add(course);
            #endregion

            #region CourseItems
            context.CourseItems.Add(courseItem);
            context.CourseItems.Add(courseItem2);
            #endregion


            #region Bookmarks
            context.Bookmarks.Add(bookmark1);
            context.Bookmarks.Add(bookmark2);
            #endregion

            

            //#region SearchQueries
            //context.SearchQueries.Add(searchQuery1);
            //context.SearchQueries.Add(searchQuery2);
            //context.SearchQueries.Add(searchQuery3);
            //#endregion

            //context.SaveChanges();
        }
    }
}
