namespace BulbaCourses.GlobalSearch.Data.Migrations
{
    using BulbaCourses.GlobalSearch.Data.Models;
    using System;
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
            #region SearchQueriesSeed
            context.SearchQueries.AddOrUpdate(x => x.Id,
                new SearchQueryDB
                {
                    Id = Guid.NewGuid().ToString(),
                    Query = "basics of c#",
                    Created = DateTime.Now
                },
                new SearchQueryDB
                {
                    Id = Guid.NewGuid().ToString(),
                    Query = "c# advanced",
                    Created = DateTime.Now
                },
                new SearchQueryDB
                {
                    Id = Guid.NewGuid().ToString(),
                    Query = "php 9 podcast",
                    Created = DateTime.Now
                },
                new SearchQueryDB
                {
                    Id = Guid.NewGuid().ToString(),
                    Query = "develop c++",
                    Created = DateTime.Now
                },
                new SearchQueryDB
                {
                    Id = Guid.NewGuid().ToString(),
                    Query = "terminator 3",
                    Created = DateTime.Now
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
            #region CoursesSeed
            context.Courses.AddOrUpdate(x => x.Id,
                new CourseDB()
                {
                    AuthorId = 2,
                    CategoryId = 1,
                    Id = "1",
                    Name = "C video course",
                    Description = "Full c video course in 4k"
                });
            #endregion
            #region CourseItems
            context.CourseItems.AddOrUpdate(x => x.Id,
                new CourseItemDB()
                {
                    Id = Guid.NewGuid().ToString(),
                    CourseDBId = "1",
                    Name = "Video 1",
                    Description = "Video number one description",
                    Url = "https://sdf.com"
                });
            #endregion
        }
    }
}
