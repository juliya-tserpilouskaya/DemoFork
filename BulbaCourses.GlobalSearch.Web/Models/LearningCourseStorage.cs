using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.GlobalSearch.Web.Models
{
    public static class LearningCourseStorage
    {
        public static List<LearningCourse> _courses = new List<LearningCourse>()
        {
            new LearningCourse()
            {
                Id = Guid.NewGuid().ToString(),
                Items = new List<LearningCourseItem>()
                {
                    new Video()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Introduction: PartOne",
                        Description = "In this video we will introduct the .NET platform features. ",
                        Duration = "3 hours"
                    },
                    new Video()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Introduction: PartTwo",
                        Description = "In this video we will introduct the .NET platform features. ",
                        Duration = "3 hours"
                    },
                },
                Name = "C# Basics",
                Category = "Video",
                Cost = 20.0,
                Complexity = "Easy",
                Language = "En",
                Description = "C# basics video course for beginners",
                AuthorId = 1,
            },
            new LearningCourse()
            {
                Id = Guid.NewGuid().ToString(),
                Items = new List<LearningCourseItem>()
                {
                    new Text()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Main Part: PartOne",
                        Description = "In this video we will introduct another .NET platform features. ",
                        MinutesRead = 20,
                    },
                    new Text()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Main Part: PartTwo",
                        Description = "In this video we will introduct another .NET platform features. ",
                        MinutesRead = 65,
                    },
                },
                Name = "C# Advanced",
                Category = "Text",
                Cost = 20.0,
                Complexity = "Medium",
                Language = "En",
                Description = "C# advanced tutorial",
                AuthorId = 2,
            },
            new LearningCourse()
            {
                Id = Guid.NewGuid().ToString(),
                Items = new List<LearningCourseItem>()
                {
                    new Podcast()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Microservices: introduction",
                        Description = "Backend architecture",
                        Duration = "6 hours"
                    },
                    new Podcast()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Micro frontends: Beginning",
                        Description = "Frontend architecture ",
                        Duration = "3 hours"
                    },
                    new Podcast()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Discussion",
                        Description = "Pros and cons",
                        Duration = "2 hours"
                    },
                },
                Name = "Microservices",
                Category = "Podcast",
                Cost = 20.0,
                Complexity = "Medium",
                Language = "En",
                Description = "Discuss microservices",
                AuthorId = 2,
            },
        };
        public static IEnumerable<LearningCourse> GetAllCourses()
        {
            return _courses.AsReadOnly();
        }

        public static LearningCourse GetById(string id)
        {
            return _courses.SingleOrDefault(c => c.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        public static IEnumerable<LearningCourse> GetByCategory(string category)
        {
            return _courses.Where(course => course.Category.Contains(category));
        }

        public static IEnumerable<LearningCourse> GetByAuthorId(int id)
        {
            return _courses.Where(course => course.AuthorId == id);
        }

        public static IEnumerable<LearningCourseItem> GetLearningItemsByCourseId(string id)
        {
            return _courses.SingleOrDefault(c => c.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase)).Items;
        }

        public static IEnumerable<LearningCourse> GetCourseByComplexity(string complexity)
        {
            return _courses.Where(course => course.Complexity.Contains(complexity));
        }


        public static IEnumerable<LearningCourse> GetCourseByLanguage(string complexity)
        {
            return _courses.Where(course => course.Language.Contains(complexity));
        }

        public static IEnumerable<LearningCourse> GetCourseByQuery(string query)
        {
            return _courses.Where(course => course.Description.ToLower().Contains(query.ToLower()));
        }
    }
}