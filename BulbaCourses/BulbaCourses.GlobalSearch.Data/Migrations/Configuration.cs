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
            #region AuthorsSeed
            context.Authors.AddOrUpdate(x => x.Id,
                new AuthorDB() { Id = 1, Name = "Master Yoda"},
                new AuthorDB() { Id = 2, Name = "Richter"},
                new AuthorDB() { Id = 3, Name = "Skeet"},
                new AuthorDB() { Id = 4, Name = "Troelsen"},
                new AuthorDB() { Id = 5, Name = "Moscow Institute of Physics and Technology" },
                new AuthorDB() { Id = 6, Name = "John hopkins university" },
                new AuthorDB() { Id = 7, Name = "Duke’s Pratt School of Engineering" },
                new AuthorDB() { Id = 8, Name = "University of New Mexico" },
                new AuthorDB() { Id = 9, Name = "University of colorado" },
                new AuthorDB() { Id = 10, Name = "Google Cloud" }
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
            
            #region Course with items seed
            var course = new CourseDB()
            {
                Name = "JavaScript",
                AuthorDBId = 5,
                Description = "If you are going to learn JavaScript, this course is a great start.",
                CourseCategoryDBId = 5,
                Id = Guid.NewGuid().ToString(),
                Complexity = "Elementary",
                Cost = 1000,
                Created = DateTime.Now,
                Language = "Russian"
            };

            var courseItem = new CourseItemDB()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Part 1: basics and functions",
                Description = "You will learn the basics and learn how to write simple programs.",
                Url = "https://ru.coursera.org/learn/javascript-osnovy-i-funktsii#syllabus",
                CourseDBId = course.Id
            };

            var courseItem2 = new CourseItemDB()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "part 2: prototypes and asynchrony",
                Description = "This course continues to teach those who have already learned the basics of JavaScript.",
                Url = "https://ru.coursera.org/learn/javascript-prototipy",
                CourseDBId = course.Id
            };

            var courseOOP = new CourseDB()
            {
                Name = "ООП и паттерны проектирования в Python",
                AuthorDBId = 5,
                Description = "Классические книги по паттернам проектирования описывают их реализацию на C++, C#, Java. У языка Python есть своя специфика из-за которой он отлично подходит для использования паттернов проектирования.",
                CourseCategoryDBId = 2,
                Id = Guid.NewGuid().ToString(),
                Complexity = "Начальный",
                Cost = 1500,
                Created = DateTime.Now,
                Language = "Русский"
            };

            var courseItemOOP = new CourseItemDB()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Детали курса \"ООП и паттерны проектирования в Python\"",
                Description = "Курс включает: обучение тестированию",
                Url = "https://ru.coursera.org/learn/oop-patterns-python",
                CourseDBId = courseOOP.Id
            };

            var courseHTML = new CourseDB()
            {
                Name = "HTML, CSS, and Javascript for Web Developers",
                AuthorDBId = 6,
                Description = "Do you realize that the only functionality of a web application that the user directly interacts with is through the web page? Implement it poorly and, to the user, the server-side becomes irrelevant!",
                CourseCategoryDBId = 2,
                Id = Guid.NewGuid().ToString(),
                Complexity = "Beginner",
                Cost = 2000,
                Created = DateTime.Now,
                Language = "English"
            };

            var courseItemHTML = new CourseItemDB()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "HTML, CSS, and Javascript for Web Developers details",
                Description = "In this course, we will learn the basic tools that every web page coder needs to know. We will start from the ground up by learning how to implement modern web pages with HTML and CSS.",
                Url = "https://ru.coursera.org/learn/html-css-javascript-for-web-developers",
                CourseDBId = courseHTML.Id
            };

            var courseC = new CourseDB()
            {
                Name = "Introduction to Programming in C",
                AuthorDBId = 7,
                Description = "This specialization develops strong programming fundamentals for learners who want to solve complex problems by writing computer programs.",
                CourseCategoryDBId = 0,
                Id = Guid.NewGuid().ToString(),
                Complexity = "Beginner",
                Cost = 2500,
                Created = DateTime.Now,
                Language = "Vietnamese"
            };

            var courseItemC = new CourseItemDB()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "\"Introduction to Programming in C\" details",
                Description = "Through four courses, you will learn to develop algorithms in a systematic way and read and write the C code to implement them.",
                Url = "https://ru.coursera.org/specializations/c-programming",
                CourseDBId = courseC.Id
            };

            var courseApWebI = new CourseDB()
            {
                Name = "Desarrollo de Aplicaciones Web: Conceptos Basicos",
                AuthorDBId = 8,
                Description = "Este curso le dara los conocimienots basicos, la terminologia y los conceptos fundamentales que son necesarios para construir aplicaciones web integradas modernas.",
                CourseCategoryDBId = 0,
                Id = Guid.NewGuid().ToString(),
                Complexity = "Beginner",
                Cost = 3000,
                Created = DateTime.Now,
                Language = "Espanol"
            };

            var courseItemApWebI = new CourseItemDB()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Detalles del curso de desarrollo de aplicaciones web: conceptos clave",
                Description = "En este curso vamos a aprender practicando. Vamos a empezar por el aprendizaje de los principales componentes de las arquitecturas de aplicaciones web, junto con los patrones de diseno fundamentales y filosofias que se utilizan para organizarlos.",
                Url = "https://ru.coursera.org/learn/aplicaciones-web",
                CourseDBId = courseApWebI.Id
            };

            var courseApWeb = new CourseDB()
            {
                Name = "Web Application Development: Basic Concepts",
                AuthorDBId = 8,
                Description = "This course will give you the basic background, terminology and fundamental concepts that you need to understand in order to build modern full stack web applications.",
                CourseCategoryDBId = 0,
                Id = Guid.NewGuid().ToString(),
                Complexity = "Beginner",
                Cost = 2000,
                Created = DateTime.Now,
                Language = "English"
            };

            var courseItemApWeb = new CourseItemDB()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "\"Web Application Development: Basic Concepts\" details",
                Description = "In this course we will learn by doing.  We will start by learning the major components of web application architectures, along with the fundamental design patterns and philosophies that are used to organize them.",
                Url = "https://ru.coursera.org/learn/web-app",
                CourseDBId = courseApWeb.Id
            };

            var courseData = new CourseDB()
            {
                Name = "Data Structures and Design Patterns for Game Developers",
                AuthorDBId = 9,
                Description = "This course is the fourth course in the specialization about learning how to develop video games using the C# programming language and the Unity game engine on Windows or Mac.",
                CourseCategoryDBId = 0,
                Id = Guid.NewGuid().ToString(),
                Complexity = "Advanced",
                Cost = 5000,
                Created = DateTime.Now,
                Language = "English"
            };

            var courseItemData = new CourseItemDB()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "\"Data Structures and Design Patterns for Game Developers\" details",
                Description = "This course assumes you have the prerequisite knowledge from the previous three courses in the specialization. You should make sure you have that knowledge, either by taking those previous courses or from personal experience, before tackling this course.",
                Url = "https://ru.coursera.org/learn/data-structures-design-patterns",
                CourseDBId = courseData.Id
            };

            var courseG = new CourseDB()
            {
                Name = "Develop and Deploy Windows Applications on Google Cloud Platform",
                AuthorDBId = 10,
                Description = "Learn to deploy and run Microsoft Windows applications on Google Cloud Platform (GCP).",
                CourseCategoryDBId = 0,
                Id = Guid.NewGuid().ToString(),
                Complexity = "Advanced",
                Cost = 5000,
                Created = DateTime.Now,
                Language = "English"
            };

            var courseItemG = new CourseItemDB()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "\"Develop and Deploy Windows Applications on Google Cloud Platform\" details",
                Description = " You will also learn how to develop and deploy ASP.NET applications and deploy them to Google Compute Engine, Google App Engine, and Google Container Engine.",
                Url = "https://ru.coursera.org/learn/develop-windows-apps-gcp",
                CourseDBId = courseG.Id
            };
            #endregion

            #region BookmarksSeed
            var bookmark1 = new BookmarkDB()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = "bd419aca-497f-4ff8-aaf2-53bcaf6131f5", //user test@test.com
                Title = "Develop and Deploy Windows Applications on Google Cloud Platform",
                Description = "Learn to deploy and run Microsoft Windows applications on Google Cloud Platform (GCP).",
                URL = "ru.coursera.org/learn/develop-windows-apps-gcp"
            };

            var bookmark2 = new BookmarkDB()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = "bd419aca-497f-4ff8-aaf2-53bcaf6131f5", //user test@test.com
                Title = "Data Structures and Design Patterns for Game Developers",
                Description = "This course assumes you have the prerequisite knowledge from the previous three courses in the specialization. You should make sure you have that knowledge, either by taking those previous courses or from personal experience, before tackling this course.",
                URL = "ru.coursera.org/learn/data-structures-design-patterns"
            };

            var bookmark3 = new BookmarkDB()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = "636cdace-e692-4fda-8aac-8c192920a83b", //user test2@test.com
                Title = "Web Application Development: Basic Concepts",
                Description = "In this course we will learn by doing.  We will start by learning the major components of web application architectures, along with the fundamental design patterns and philosophies that are used to organize them.",
                URL = "ru.coursera.org/learn/web-app"
            };
            #endregion

            #region CoursesAdd
            context.Courses.Add(course);
            context.Courses.Add(courseOOP);
            context.Courses.Add(courseHTML);
            context.Courses.Add(courseC);
            context.Courses.Add(courseApWebI);
            context.Courses.Add(courseApWeb);
            context.Courses.Add(courseData);
            context.Courses.Add(courseG);
            #endregion

            #region CourseItemsAdd
            context.CourseItems.Add(courseItem);
            context.CourseItems.Add(courseItem2);
            context.CourseItems.Add(courseItemOOP);
            context.CourseItems.Add(courseItemHTML);
            context.CourseItems.Add(courseItemC);
            context.CourseItems.Add(courseItemApWebI);
            context.CourseItems.Add(courseItemApWeb);
            context.CourseItems.Add(courseItemData);
            context.CourseItems.Add(courseItemG);
            #endregion

            #region BookmarksAdd
            context.Bookmarks.Add(bookmark1);
            context.Bookmarks.Add(bookmark2);
            context.Bookmarks.Add(bookmark3);
            #endregion

            //context.SaveChanges();
        }
    }
}
