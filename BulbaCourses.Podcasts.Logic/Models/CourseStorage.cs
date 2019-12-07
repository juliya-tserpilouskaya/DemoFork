using BulbaCourses.Podcasts.Logic.Models;
using System.Collections.Generic;

namespace BulbaCourses.Podcasts.Logic.Services
{
    internal static class CourseStorage
    {
        private static List<Course> Courses = new List<Course>()
        {
            new Course()
            {
                Title = "course 1",
                Author = "bob",
                Theme = "c#",
                Price = 10.0
            },
            new Course()
            {
                Title = "course 2",
                Author = "bor",
                Theme = "c++",
                Price = 20.0
            },
            new Course()
            {
                Title = "cource 3",
                Author = "borr",
                Theme = "c",
                Price = 30.0
            }
        };
        internal static SearchResultList Search(string _string, SearchMode searchtype) //add caching
        {
            SearchResultList resultList = new SearchResultList();
            switch(searchtype)
            {
                case SearchMode.ByTitle:
                    foreach (Course course in Courses)
                    {
                        if (_string.Length > course.Title.Length)
                            continue;
                        else
                        {
                            if (course.Title.ToLower().Contains(_string.ToLower()))
                            {
                                resultList.Add(new SearchResult
                                {
                                    Title = course.Title,
                                    Price = course.Price,
                                    Author = course.Author,
                                    Theme = course.Theme
                                });
                            }
                        }
                        if (resultList.Length() >= SearchService.SearchCount)
                            return resultList;
                    }
                    break;

                case SearchMode.ByAuthor:
                    foreach (Course course in Courses)
                    {
                        if (_string.Length > course.Author.Length)
                            continue;
                        else
                        {
                            if (course.Author.ToLower().Contains(_string.ToLower()))
                            {
                                resultList.Add(new SearchResult
                                {
                                    Title = course.Title,
                                    Price = course.Price,
                                    Author = course.Author,
                                    Theme = course.Theme
                                });
                            }
                        }
                        if (resultList.Length() >= SearchService.SearchCount)
                            return resultList;
                    }
                    break;

                case SearchMode.ByTheme:
                    foreach (Course course in Courses)
                    {
                        if (_string.Length > course.Theme.Length)
                            continue;
                        else
                        {
                            if (course.Theme.ToLower().Contains(_string.ToLower()))
                            {
                                resultList.Add(new SearchResult
                                {
                                    Title = course.Title,
                                    Price = course.Price,
                                    Author = course.Author,
                                    Theme = course.Theme
                                });
                            }
                        }
                        if (resultList.Length() >= SearchService.SearchCount)
                            return resultList;
                    }
                    break;
            }
            
            throw new KeyNotFoundException();
        }
    }
}